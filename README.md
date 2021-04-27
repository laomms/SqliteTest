# c#调用sqlite3.dll实例  
非system.data.sqlite.dll

数据库目录中带有中文的话用sqlite3_open16打开数据库:sqlite3_open16(Marshal.StringToHGlobalUni("中文路径"), ref hSqlite)    
数据库内容含有中文的的话用sqlite3_bind_text16来绑定: sqlite3_bind_text16(stmt, 1, Marshal.StringToHGlobalUni("中文内容"), -1, transient)    

