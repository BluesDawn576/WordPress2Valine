# WordPress2Valine

简体中文 | [English](https://github.com/BluesDawn576/WordPress2Valine/blob/master/README.md)

非 WordPress 插件

## 使用方法

### 通过 phpmyadmin 或其他软件导出表 `wp_comments` 为 `json`

⚠️需要注意的是 WordPress 每个文章/页面都有一个唯一的内部 id

如果原页面 id 格式与当前页面不同的话，将无法显示评论  
请手动替换已经更改的 id 格式

> 假设固定链接已设为 `/?p=%post_id%`  
> https://example.com/?p=42 => https//example.com/friend/

```
Example:
WordPress = 42 => Valine = /42/
```
```
替换：42,friend
```
```
WordPress = 42 => Valine = /friend/
```

### 导入评论数据 (LeanCloud)

数据存储 - 导入导出 - 数据导入

![leancloud_cn.png](https://s2.loli.net/2023/05/23/ldjq5B8shTvmDZp.png)