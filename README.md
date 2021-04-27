# c#调用sqlite3.dll实例  
非system.data.sqlite.dll

数据库目录中带有中文的话用sqlite3_open16打开数据库:sqlite3_open16(Marshal.StringToHGlobalUni("中文路径"), ref hSqlite)    
                                                sqlite3_prepare16_v2(hSqlite, Marshal.StringToHGlobalUni(sql), num, ref stmt, transient)    
数据库内容含有中文的的话用sqlite3_bind_text16来绑定: sqlite3_bind_text16(stmt, 1, Marshal.StringToHGlobalUni("中文内容"), -1, transient)    
表名不建议用中文,因为原生sqlite3.dll没有sqlite3_exec16函数,所以得用代码中的StringToPointer函数进行转换，后续对该中文表名中数据内容更新也得用转换函数,比较麻烦.     

