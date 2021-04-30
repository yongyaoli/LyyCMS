

# 配置52ABP-PRO的多语言
 
 
**请注意：**
- 从52ABP-PRO 2.5.0的版本开始默认采用json配置多语言
- 属性名和字段不能重复否则框架会验证失败，需要你删除重复的键名

## Json的配置方法如下

在LyyCMS.Core类库中，找到路径为 Localization->SourceFiles->Json文件夹下的对应文件

### 中文本地化的内容Chinese localized content

找到Json文件夹下的LyyCMS-zh-Hans.json文件，复制以下代码进入即可。

> 请注意防止键名重复，产生异常

```json
                    //验证码的多语言配置==>中文
                    
                     "VerificationCodemember": "member",
                    "VerificationCodememberInputDesc": "请输入member",
                     
"SendTime": "SendTime",
"ExpireTime": "ExpireTime",
                    
                     "VerificationCodeCode": "Code",
                    "VerificationCodeCodeInputDesc": "请输入Code",
                     
"Count": "Count",
					                     
                    "VerificationCode": "验证码",
                    "ManageVerificationCode": "管理验证码",
                    "QueryVerificationCode": "查询验证码",
                    "CreateVerificationCode": "添加验证码",
                    "EditVerificationCode": "编辑验证码",
                    "DeleteVerificationCode": "删除验证码",
                    "BatchDeleteVerificationCode": "批量删除验证码",
                    "ExportVerificationCode": "导出验证码",
                    "VerificationCodeList": "验证码列表",
                     //验证码的多语言配置==End
                    


```


### 英语本地化的内容English localized content
找到Json文件夹下的LyyCMS.json文件，复制以下代码进入即可。
```json
             //验证码的多语言配置==>英文
                    
                     "VerificationCodemember": "VerificationCodemember",
                    "VerificationCodememberInputDesc": "Please input your VerificationCodemember",
                     
"SendTime": "SendTime",
"ExpireTime": "ExpireTime",
                    
                     "VerificationCodeCode": "VerificationCodeCode",
                    "VerificationCodeCodeInputDesc": "Please input your VerificationCodeCode",
                     
"Count": "Count",
					                     
                    "VerificationCode": "VerificationCode",
                    "ManageVerificationCode": "ManageVerificationCode",
                    "QueryVerificationCode": "QueryVerificationCode",
                    "CreateVerificationCode": "CreateVerificationCode",
                    "EditVerificationCode": "EditVerificationCode",
                    "DeleteVerificationCode": "DeleteVerificationCode",
                    "BatchDeleteVerificationCode": "BatchDeleteVerificationCode",
                    "ExportVerificationCode": "ExportVerificationCode",
                    "VerificationCodeList": "VerificationCodeList",
                     //验证码的多语言配置==End
                    




```