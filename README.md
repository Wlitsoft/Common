# Wlitsoft.Framework.Common
[![Build status](https://ci.appveyor.com/api/projects/status/a8op6vx5r19uatve?svg=true)](https://ci.appveyor.com/project/Wlitsoft/common-nr225)
​该项目是一个开发中经常使用的功能类库，封装了对象序列化反序列化、网络请求、参数加密、日志、缓存接口、以及常用的字符串操作等。

## 相关配置

在应用初始化代码中可以操作以下配置：

> 添加序列化者

例：将默认的 Json 序列化者修改为 JSON.Net 实现。

`App.Builder.AddSerializer(SerializeType.Json, new JsonNetJsonSerializer());`



> 以 xml 配置文件的方式设置 log4net 日志记录者

`App.Builder.SetLog4NetLoggerByXmlConfig("~/Config/log4net.conf");`



> 设置分布式缓存

例：将分布式缓存实现为 Redis 分布式缓存实现

`App.Builder.App.Builder.SetDistributedCache(new RedisCache());`

注：RedisCache 详见 Caching 项目。



