# GiteaAssistant

Git提交统计工具

### 使用说明

1. 打开“跨域测试”的chorme快捷方式（如果不是默认安装目录可能无法生效，自行修改下chorme的路径即可），主要是添加了`--args --disable-web-security --user-data-dir="C:/ChromeDevSession"` 这些参数，允许浏览器访问跨域接口。
2. 首先需要先获取用户列表，部分用户存在本地git用户名与平台不一致的情况，需要手动指定别名，如果存在多个别名的，可以用`,`英文逗号字符分开。
3. 为了加快统计速度可以取消一些不需要统计的用户的启用。
4. 切换到统计配置页，选择日期范围。
5. 点击开始统计分数，网页会自动开始统计流程，由于需要遍历请求所有仓库列表，再遍历请求每个仓库的分支列表，再遍历请求每个分支的提交记录，因此整个过程耗时会较多。大约需要半分钟左右的时间。
6. 统计过程中会有日志输出，点击保存日志（目前会保存在浏览器缓存里），可以方便下次查看。
7. 统计结束后，可以切换到提交记录页面和数据统计页面查看统计详情。提交记录页面会展示所有的提交信息。数据统计会根据当前的分数规则计算出分数，并且会排除一些不符合规范的提交记录。



### 统计规则
    
1. commit  规范提交 计 2 分 （去除重复提交与不规范提交）
2. 发布版本 计 5 分

### Gitea API 使用说明

1. 在个人管理页面添加访问token
2. 查阅 [Gitea API手册](http://192.168.0.222:8080/api/swagger#/)
