/* Uses actual execution adapter and practice UI with a controlled runner response. */
const assert = require('node:assert/strict');
const fs = require('node:fs');
const {JSDOM} = require(process.env.CSCS_JSDOM_PATH || 'jsdom');
(async () => {
 const dom = new JSDOM(fs.readFileSync('_build/html/chapters/03_decision/0302_ifstatement.html','utf8'),{url:'https://book.example/chapters/03_decision/0302_ifstatement.html',runScripts:'outside-only'});
 const w=dom.window; await new Promise(resolve=>w.addEventListener('load',resolve,{once:true}));
 let mode='correct',calls=[];
 w.fetch=async (url,options)=>{
  const {code,stdin}=JSON.parse(options.body);calls.push({url,code,stdin,headers:options.headers});
  if(mode==='network')throw new Error('Runner unavailable');
  let output='';
  if(/int score =/.test(code)){const score=Number(code.match(/int score = (\d+)/)[1]);output=score>=90?'Distinction':score>=60?'Pass':'No pass';}
  else {const service=code.match(/string service = "(.*?)"/)[1],total=Number(code.match(/decimal orderTotal = ([\d.]+)m/)[1]);output={E:'Service E: 8',S:total>=50?'Service S: 0':'Service S: 3',P:'Service P: 0'}[service]||'Unknown service';}
  return {ok:true,json:async()=>({output:mode==='wrong'?'Wrong\n':output+'\n',exitCode:mode==='compile'?1:0,error:mode==='compile'?'Compilation failed':''})};
 };
 w.cscsPress={authHeader:async()=>({'X-Test-Pass':'present'})};
 w.eval(fs.readFileSync('_static/execution.js','utf8'));
 w.eval(fs.readFileSync('_static/section_practice.js','utf8'));
 async function check(kind){
  const area=w.document.querySelector(`[data-practice-tests="${kind}"]`),button=area.querySelector('button');button.click();
  for(let i=0;i<100&&button.disabled;i++)await new Promise(resolve=>setTimeout(resolve,1));
  assert(!button.disabled);return area;
 }
 for(const [kind,count] of [['scores',5],['delivery',7]]){
  const area=w.document.querySelector(`[data-practice-tests="${kind}"]`),cell=[...w.document.querySelectorAll('[data-cscs-cell-id]')].find(c=>c.dataset.cscsCellId===area.dataset.practiceCell),editor=cell.querySelector('.cscs-code-editor'),before=editor.value;
  calls=[];mode='correct';let result=await check(kind);assert.match(result.textContent,new RegExp(`${count} of ${count} cases passed`));assert.equal(calls.length,count);assert.equal(editor.value,before);assert(calls.every(c=>c.headers['X-Test-Pass']==='present'&&c.stdin===''));
  mode='wrong';result=await check(kind);assert.match(result.textContent,new RegExp(`0 of ${count}`));assert.match(result.textContent,/FAIL/);
  mode='compile';calls=[];result=await check(kind);assert.match(result.textContent,/remaining cases were not run/);assert.equal(calls.length,1);
  mode='network';result=await check(kind);assert.match(result.textContent,/Check incomplete: Runner unavailable/);
  editor.value=before.replace(kind==='scores'?'int score = 95;':'decimal orderTotal = 50m;','');calls=[];result=await check(kind);assert.match(result.textContent,/Keep exactly one/);assert.equal(calls.length,0);editor.value=before;
 }
 // The ordinary Run control still uses the shared execution transport.
 mode='correct';const scoreCell=w.document.querySelector('[data-cscs-cell-id="core19_choice_starter"]');scoreCell.querySelector('.cscs-run-button').click();
 await new Promise(resolve=>setTimeout(resolve,5));assert.match(scoreCell.querySelector('.cscs-execution-output').textContent,/Distinction/);
 const result={real_execution_adapter:true,score_cases:5,delivery_cases:7,current_editor_preserved:true,wrong_output_rejected:true,compile_failure_stops:true,network_failure_reported:true,invalid_declarations_not_run:true,ordinary_run_transport:true,live_runner_api_tested:false};
 fs.writeFileSync('authoring/section_practice_pilot/tabs34_dom_verification.json',JSON.stringify(result,null,2)+'\n');console.log(result);w.close();
})().catch(error=>{console.error(error);process.exitCode=1;});
