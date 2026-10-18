import concurrent.futures,json,subprocess,os
from pathlib import Path
R=Path(__file__).resolve().parents[1];O=R/'authoring/ba_development_revision';cases=json.loads((O/'code_cases.json').read_text());work=Path('/tmp/ba18_code');work.mkdir(exist_ok=True);Path('/tmp/cscs_empty_nuget').mkdir(exist_ok=True)
prior = json.loads((O/'code_verification.json').read_text()) if (O/'code_verification.json').exists() else []
def run(c):
 cached=next((r for r in prior if r.get('passed') and all(r.get(k)==c.get(k) for k in ['cell_id','source','stdin','package','expected_stdout'])),None)
 if cached: return {**c, **{k:cached[k] for k in ['passed','actual_stdout','stderr','build']}, 'reused_unchanged_pass':True}
 p=work/c['cell_id'];p.mkdir(exist_ok=True);(p/'Program.cs').write_text(c['source']);package='<ItemGroup><PackageReference Include="Microsoft.Data.Sqlite" Version="10.0.13" /></ItemGroup>' if c.get('package') else ''
 (p/'Check.csproj').write_text('<Project Sdk="Microsoft.NET.Sdk"><PropertyGroup><OutputType>Exe</OutputType><TargetFramework>net10.0</TargetFramework><ImplicitUsings>enable</ImplicitUsings><Nullable>enable</Nullable><NuGetAudit>false</NuGetAudit><UseSharedCompilation>false</UseSharedCompilation></PropertyGroup>'+package+'</Project>')
 a=subprocess.run(['dotnet','build','--nologo','-v:q','--source','/tmp/cscs_empty_nuget'],cwd=p,capture_output=True,text=True,timeout=70)
 if a.returncode:return {**c,'passed':False,'build':a.stdout+a.stderr}
 b=subprocess.run(['dotnet',str(p/'bin/Debug/net10.0/Check.dll')],input=c['stdin'],cwd=p,capture_output=True,text=True,timeout=20);out=b.stdout.replace('\r\n','\n');passed=b.returncode==0 and (c['expected_stdout'] is None or c['expected_stdout']==out)
 return {**c,'passed':passed,'actual_stdout':out,'stderr':b.stderr,'build':a.stdout+a.stderr}
with concurrent.futures.ThreadPoolExecutor(max_workers=2) as pool:
 results=[]
 for result in pool.map(run,cases):
  results.append(result);print(('PASS' if result['passed'] else 'FAIL'),result['file'].split('/')[-1],result['cell_id'],flush=True)
  if not result['passed']:print(result.get('build',''),result.get('actual_stdout',''),flush=True)
(O/'code_verification.json').write_text(json.dumps(results,indent=2)+'\n')
# Preserve original outputs. Save verified output for new code cells only.
for p in {c['file'] for c in cases}:
 n=json.loads((R/p).read_text());by={c['id']:c for c in n['cells']}
 for c in results:
  if c['file']!=p or not c['passed'] or not c['cell_id'].startswith('ba18_') or c['role']=='project_listing':continue
  out=c['actual_stdout'];by[c['cell_id']]['outputs']=[{'output_type':'stream','name':'stdout','text':out.splitlines(True)}] if out else [];by[c['cell_id']]['execution_count']=1
 (R/p).write_text(json.dumps(n,ensure_ascii=False,indent=1)+'\n')
assert all(r['passed'] for r in results), 'See code_verification.json'
print(len(results),'independent C# programs passed',flush=True)
