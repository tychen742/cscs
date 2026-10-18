import json,subprocess,tempfile,math
from pathlib import Path
R=Path(__file__).resolve().parents[1];O=R/'authoring/integration_cleanup';b=json.load(open(O/'baseline.json'));moves=json.load(open(O/'cell_moves.json'));cases=[]
for m in moves:
 if m['from_path']==m['to_path']:continue
 c=next(c for c in b[m['from_path']]['cells'] if c['id']==m['from_id'])
 if c['cell_type']=='code':cases.append((m,c))
records=[]
with tempfile.TemporaryDirectory(prefix='cscs_moved_') as directory:
 d=Path(directory);(d/'NuGet.Config').write_text('<configuration><packageSources><clear /></packageSources></configuration>')
 (d/'Check.csproj').write_text('<Project Sdk="Microsoft.NET.Sdk"><PropertyGroup><OutputType>Exe</OutputType><TargetFramework>net10.0</TargetFramework><ImplicitUsings>enable</ImplicitUsings><Nullable>enable</Nullable><NuGetAudit>false</NuGetAudit></PropertyGroup></Project>')
 (d/'Program.cs').write_text('System.Console.WriteLine("setup");')
 p=subprocess.run(['dotnet','restore','--configfile','NuGet.Config'],cwd=d,capture_output=True,text=True,timeout=60);assert p.returncode==0,p.stdout+p.stderr
 for m,c in cases:
  (d/'Program.cs').write_text(''.join(c['source']))
  p=subprocess.run(['dotnet','build','--no-restore','--nologo','-v:q'],cwd=d,capture_output=True,text=True,timeout=60);assert p.returncode==0,p.stdout+p.stderr
  run=subprocess.run(['dotnet',str(d/'bin/Debug/net10.0/Check.dll')],input='21\n',cwd=d,capture_output=True,text=True,timeout=15);assert run.returncode==0,run.stderr
  output=run.stdout.replace('\r\n','\n');key=c['id']
  if key=='2239a9b4':assert 'ageInput is a System.String' in output and 'age still has the same value: 21' in output and 'data type is now: System.Int32' in output
  elif key in ['30b29485','05cd7489']:assert output=='34.5\n'
  elif key=='175cc166':assert output=='1\n2\n3\n4\n'
  elif key in ['17923016','22156745','67e9a688']:
   lines=output.splitlines();lines=lines[1:] if key=='67e9a688' else lines;assert len(lines)==10
   for i,line in enumerate(lines,1):
    cols=line.split();assert list(map(int,cols[:3]))==[i,i*i,i*i*i];assert math.isclose(float(cols[3]),math.sqrt(i),abs_tol=0.000051)
  elif key=='fabe71ea':assert output=='123456789\n    stuff\n  stuff\nstuff\nstuff\n'
  elif key=='daa334888eb8':assert output=='Arrival: 300,100,200,100\nReport: 100,100,200,300\n2\n'
  elif key=='512276a8':assert output=='minimum-hop route=HQ->Client, hops=1\nthat route costs 100; feasible two-hop route costs 2\n'
  else:raise AssertionError(key)
  records.append({**m,'compiled':True,'semantic_output_checks_pass':True,'stdout':output,'compiler_warnings':'warning ' in p.stdout})
(O/'moved_code_verification.json').write_text(json.dumps(records,indent=2)+'\n');print(f'{len(records)} moved code cells compile/run independently and pass expected-result checks.')
