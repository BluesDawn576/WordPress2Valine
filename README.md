# WordPress2Valine

[简体中文](https://github.com/BluesDawn576/WordPress2Valine/blob/master/README_CN.md) | English

This is NOT a WordPress plugin.

## ⚠️关于 LeanCloud 停止对外提供服务的通知

Notice on LeanCloud Discontinuing External Services

[https://docs.leancloud.app/en/sdk/announcements/sunset-announcement/](https://docs.leancloud.app/en/sdk/announcements/sunset-announcement/)

The method of importing comment data into LeanCloud is no longer applicable.

## How to use

### Export the `wp_comments` table as `json` using phpmyadmin or other software

⚠️ATTENTION: Each post or page in WordPress has a unique internal identifier.

If the original page identifier is different from the current page, the comments on that page will not be displayed.  
Please replace the changed identifier manually.

> Suppose the permalink has been set to `/?p=%post_id%`  
> https://example.com/?p=42 => https//example.com/friend/

```
Example:
WordPress = 42 => Valine = /42/
```
```
The value to replace: 42,friend
```
```
WordPress = 42 => Valine = /friend/
```

### Import comments (LeanCloud)


Data Storage - Import/export - Import

![leancloud_en.png](https://s2.loli.net/2023/05/23/jazWBcxs53ZlFir.png)
