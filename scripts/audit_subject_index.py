import json,re,html,collections,pickle
from pathlib import Path
from bs4 import BeautifulSoup
R=Path(__file__).resolve().parents[1];O=R/'authoring/index_audit';B=Path('/tmp/cscs-section-revision/_build/html')
entries=json.loads((O/'entries.json').read_text());terms=list(entries)
# Decisions are tied to this exact reviewed inventory. Refuse to apply numeric
# review IDs to a changed term list or changed location set.
env=pickle.load((B.parent/'.doctrees/environment.pickle').open('rb'))
current=collections.defaultdict(list)
for doc, locations in env.domaindata['index']['entries'].items():
 for kind,value,target,main,category in locations:
  current[value].append({'document':doc,'target':target,'kind':kind})
assert dict(sorted(current.items(),key=lambda item:item[0].casefold())) == entries, 'Index inventory changed: recollect and re-review decisions before rerunning.'

# Editorial decisions apply only to this review, not to the generated index.
rewrite_ids='3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 27 28 29 33 34 35 42 43 70 71 72 76 80 84 85 86 87 88 89 96 97 106 109 110 112 119 120 122 124 125 126 127 128 129 130 138 157 166 167 168 171 172 175 177 178 180 181 182 183 185 186 187 188 192 193 194 199 200 201 203 207 212 213 214 215 216 217 218 219 220 221 222 223 224 225 226 227 228 229 231 236 238 239 240 241 242 256 259 262 271 273 274 275 276 277 278 279 280 281 282 283 284 288 292 293 294 296 297 298 299 300 301 302 303 304 306 307 310 311 319 320 326 327 328 329 330 331 332 333 337 338 339 341 342 343 344 345 348 349 350 351 352 358 359 361 362 363 364 365 366 367 368 371 372 373 376 377 379 380 381 385 386 387 388 389 390 391 392 393 396 397 398 399 412 413 414 419 420 421 422 423 424 425 427 428 438 439 446 447 448 449 450 454 456 457 458 459 461 462 463 466 469 470 471 473 474 477 491 492 496 497 498 500 501 502 504 505 506 507 508 509 510 514 515 516 517 518 519 520 522 525 526 527 528 532 533 534 535 536 537 539 540 542 543 554 555 556 578 580 586 594 595 597 598 599 600 601 602 603 604 605 606 607 608 609 610 611 612 613 614 615 616 617 622 623 630 631 636 649 650 651 654 655 656 657 658 659 661 664 667 668 670 672 673 674 684 686 687 689 690 691 693 695 697 698 699 700 701 702 703 704 705 706 707 722 723 724 725 726 727 738 740 741 742 743 746 752 753 754 757 758 759 760 761 766 767 768 770 772 776 777 778 779 780 781 782 784 785 788 789 790 791 792 796 797 801 802 803 804 807 811 812 813 814 815 817 818 819 820 821 822 830 834 835 836 837 838 839 841 842 843 844 845 846 847 848 849 850 851 858 862 864 865 867 870 872 873 874 875 876 877 878 879 882 883 887 888 889 890 894 896 900 902 903 904 906 907 908 909 910 911 912 913 914 915 916 917 918 919 920 921 924 925 927 930 931 932 933 934 937 938 939 940 941 942 943 944 946 951 957 979 982 983 984 985 987 989 990 995 996 997 998 999 1000 1001 1002 1003 1004 1005 1006 1007 1008 1009 1010 1011 1012 1013 1014 1015 1016 1017 1019 1020 1021 1024 1025 1026 1027 1028 1029 1031 1035 1036 1037 1040 1041 1042 1043 1044 1049 1050 1051 1052 1056 1058 1059 1060 1061 1062 1064 1065 1066 1067 1068 1069 1070 1072 1073 1074 1075 1077 1078 1079 1080 1081 1082 1086 1088 1090 1092 1093 1094 1095 1096 1097 1100 1101 1102 1103 1104 1111 1114 1115 1116 1118 1119 1120 1121 1122 1123 1125 1126 1130 1131 1132 1133 1134 1136 1137 1144 1145 1146 1147 1148 1149 1151 1152 1153 1163 1166 1167 1168 1169 1177 1178 1179 1180 1181 1182 1183 1184 1185 1186 1187 1188 1189 1190 1191 1192 1201 1203 1204 1224 1225 1226 1227 1228 1229 1230 1231 1232 1233 1234 1235 1240 1242 1243 1244 1250 1251 1252 1253 1254 1255 1256 1257 1258 1259 1260 1261 1262 1263 1264 1265 1266 1267 1268 1269 1270 1271 1272 1274 1275 1280 1282 1283 1284 1285 1286 1287 1288 1289 1290 1291 1292 1293 1294 1296 1297 1298 1305 1306 1311 1312 1314 1331 1332 1333 1334 1335 1336 1337 1339 1344 1345 1347 1348 1349 1352 1355 1356 1357 1358 1359 1360 1361 1362 1363 1364 1365 1366 1367 1370 1373 1374 1375 1376 1377 1378 1379 1380 1381 1382 1383 1384 1387 1388 1401 1402 1409 1410 1411 1412 1413 1414 1416 1418 1419 1420 1421 1422 1423 1424 1425 1426 1430 1431 1432 1433'
rewrite=set(map(int,rewrite_ids.split()))
remove=set(map(int,'30 75 90 158 208 209 272 346 347 356 357 472 637 638 639 640 641 642 643 660 692 708 714 926 935 968 969 970 974 975 1167 1273 1307 1308'.split()))
# Root/subentry pairs created by the previous mechanical expansion often encode
# co-occurrence rather than a real subject/subtopic relationship.
restructure=set(map(int,'''23 46 47 48 49 50 51 52 53 54 55 56 57 58 59 60 61 62 63 64 65 66 67 68 69 73 74 98 104 107 116 117 118 134 135 136 137 145 150 151 173 174 184 190 195 196 197 232 233 234 235 247 248 251 252 254 258 260 261 263 264 265 266 267 268 269 270 289 290 291 305 308 309 312 314 315 334 335 336 353 354 369 370 400 401 402 403 404 405 406 407 408 409 410 411 415 416 417 418 430 431 432 433 434 435 436 437 451 452 453 465 467 468 478 479 480 481 482 483 484 485 486 487 488 489 490 493 494 495 529 530 531 549 550 551 557 558 559 560 561 562 563 565 566 568 569 570 575 576 577 581 582 583 584 585 587 588 589 590 591 592 593 618 619 620 621 624 625 626 627 628 629 644 645 646 647 648 652 653 665 666 677 678 679 680 681 682 683 685 694 709 710 711 712 713 715 716 717 718 719 720 745 747 748 749 750 751 762 764 773 774 775 783 786 787 793 794 795 798 799 800 808 809 810 823 824 825 826 827 828 829 831 832 833 852 853 854 855 856 857 859 860 863 866 868 869 871 885 886 897 898 899 922 923 928 929 947 948 949 950 952 953 954 955 956 959 960 961 963 971 972 973 976 977 978 991 992 993 1023 1030 1033 1034 1045 1046 1047 1048 1053 1055 1057 1089 1091 1098 1099 1105 1106 1107 1108 1109 1110 1112 1113 1117 1127 1128 1129 1135 1138 1139 1140 1141 1142 1143 1154 1155 1156 1157 1158 1159 1160 1161 1162 1164 1165 1170 1171 1172 1173 1174 1175 1176 1194 1195 1196 1197 1199 1200 1205 1206 1207 1208 1209 1210 1211 1212 1213 1214 1215 1216 1217 1218 1219 1220 1221 1222 1223 1236 1237 1238 1239 1241 1245 1246 1247 1248 1249 1276 1277 1278 1279 1281 1299 1300 1301 1302 1303 1304 1309 1310 1313 1315 1316 1317 1318 1319 1320 1325 1326 1327 1328 1329 1330 1342 1343 1346 1353 1354 1369 1371 1372 1385 1386 1390 1391 1392 1393 1394 1395 1396 1397 1398 1399 1400 1403 1404 1405 1406 1407 1408 1415 1417 1427 1428 1429 1434'''.split()))
# Concrete corrections, checked against the indexed lesson passages.
specific={
14:('rewrite','set; membership / frequency counting','A sentence was incorrectly treated as a main term/subentry pair.'),
409:('rewrite','Dictionary<TKey, TValue>; Keys property','Repeated words remain in the entry.'),
530:('rewrite','method; parameters','Repeated word; use the book’s C# method terminology.'),
549:('rewrite','generics; type-parameter syntax','Malformed prose about angle brackets.'),
716:('restructure','queue; Dequeue','Queue removal does not follow LIFO.'),
717:('restructure','queue; Enqueue','Queue insertion is not a LIFO operation.'),
718:('restructure','stack; LIFO / queue; FIFO','These are contrasting ordering policies, not parent and child subjects.'),
719:('restructure','stack; Pop','Preserve exact C# method capitalization and put it under its owning structure.'),
720:('restructure','stack; Push','Preserve exact C# method capitalization and put it under its owning structure.'),
751:('restructure','List<T>; collecting console input (ReadLines example)','ReadLines is a user-defined example, not a List<T> API.'),
1122:('rewrite','shortest paths; path reconstruction','Stale combined title; the indexed passage now reconstructs graph routes, not string matches.'),
1216:('restructure','parsing; numeric input / int.Parse / double.Parse','String has no Parse method; link the conversion explanation rather than only its I/O cross-reference.'),
1309:('restructure','tree; height / tree; node depth','Height and depth are distinct concepts; index each definition.'),
1048:('restructure','REPL; comparison with an operating-system shell','The lesson distinguishes these environments; avoid implying a shell is a type of language REPL.'),
550:('restructure','dynamic array; bounds checking','The bounds check belongs to index validation, not to generic type checking.'),
823:('restructure','program; entry point','Main is the entry point; a namespace groups type names.'),
826:('restructure','Main method / program; entry point','Do not bury Main under namespace.'),
827:('restructure','Program class','Do not imply that a class is a namespace subtopic.'),
32:('rewrite','collection operations; Add','Bare API name is ambiguous without owning type/context.'),
340:('rewrite','collection properties; Count','Distinguish the property from a method or mathematical count.'),
721:('rewrite','array; Length / string; Length','Property belongs to specific types; distinguish Count.'),
384:('rewrite','Queue<T>; Dequeue','Use exact API capitalization.'),
460:('rewrite','Queue<T>; Enqueue','Use exact API capitalization.'),
905:('rewrite','Stack<T>; Pop','Use exact API capitalization.'),
986:('rewrite','Stack<T>; Push','Use exact API capitalization.'),
745:('rewrite','List<T>; fundamentals','Use the actual generic collection type, distinguish it from a general list ADT.'),
746:('rewrite','List<T>; displaying elements','Replace informal “Console.WriteLine useless” with a clear lookup phrase.'),
885:('restructure','double.Parse / parsing; double','The qualified API should be directly findable.'),
886:('restructure','int.Parse / parsing; int','The qualified API should be directly findable.'),
1434:('rewrite','development tools; historical Xamarin Studio reference','Historical reference remains in an optional legacy page; identify it as historical.'),
93:('rewrite','operators; arithmetic','Unify singular/plural/operator category entries.'),
94:('rewrite','operators; arithmetic','Unify singular/plural/operator category entries.'),
1085:('rewrite','searching','Merge the search/searching variant.'),
1087:('retain','searching','Use as the preferred spelling for search/searching.'),
}
cache={};broken=[];rows=[]
for i,(term,locs) in enumerate(entries.items(),1):
 status='retain';proposed=term;reason='Topical lookup term; retain its lesson location. Apply final house-style consistency when the index is rewritten.'
 if i in rewrite:status='rewrite';proposed='Replace with the concept/API name taught at this passage';reason='Teaching heading, exercise title, or broad phrase: useful in the lesson, weak as an alphabetical lookup term.'
 if i in restructure:status='restructure';proposed='Index the concepts independently or use an explicit relationship/cross-reference';reason='The current parent/subentry grouping needs semantic review; co-occurrence alone does not establish a subject hierarchy.'
 if i in remove:status='remove';proposed='Omit from the subject index; retain in contents/navigation';reason='Book structure, assessment administration, or generic activity label rather than a subject lookup.'
 if i in specific:status,proposed,reason=specific[i]
 enriched=[]
 for loc in locs:
  p=B/(loc['document']+'.html')
  if p not in cache:cache[p]=BeautifulSoup(p.read_text(),'html.parser') if p.exists() else None
  soup=cache[p];node=soup.find(id=loc['target']) if soup else None
  if not node:broken.append(loc)
  section=node if node and node.name=='section' else node.find_parent('section') if node else None
  heading=section.find(re.compile('^h[1-6]$')) if section else None
  enriched.append({**loc,'heading':heading.get_text(' ',strip=True) if heading else '', 'excerpt':section.get_text(' ',strip=True)[:650] if section else ''})
 rows.append({'id':i,'entry':term,'decision':status,'proposal':proposed,'reason':reason,'locations':enriched})
assert len(rows)==1435 and not broken
(O/'review.json').write_text(json.dumps(rows,indent=2)+'\n')
counts=dict(collections.Counter(row['decision'] for row in rows));summary={'distinct_entries':len(rows),'indexed_locations':sum(len(r['locations']) for r in rows),'decisions':counts,'local_targets_missing':len(broken),'book_source_changed':False,'deployment':'audit only'}
(O/'summary.json').write_text(json.dumps(summary,indent=2)+'\n');print(summary)
