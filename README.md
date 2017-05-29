# FacePlusPlus
Face++非官方的C#封装，官网的接口基本都有，本地测试通过。(???为啥是非官方?因为官方没有C#版啊...捂脸哭.jpg)

1、使用了Newtonsoft.Json解析Json数据

2、使用了Flurl.Http来进行GEt和Post数据

调用方法：

FaceServiceClient fs = new FaceServiceClient("你的API Key", "你的API Secret");

var res = await fs.DetectFaceUrlAsync("http://wx4.sinaimg.cn/mw690/6828f4c2gy1fffeout5jsj20h80o5jw9.jpg");


如果你觉得本代码还不错，请考虑打赏一下作者，谢谢！

微信：

![image](https://github.com/hupo376787/FacePlusPlus/blob/master/%E5%BE%AE%E4%BF%A1%2B.png)


支付宝：

![image](https://github.com/hupo376787/FacePlusPlus/blob/master/%E6%94%AF%E4%BB%98%E5%AE%9D%2B.png)
