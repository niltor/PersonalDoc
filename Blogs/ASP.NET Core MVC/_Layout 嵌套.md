### 官方文档：
基本用法 
https://docs.microsoft.com/en-us/aspnet/core/mvc/views/layout

### 使用场景
除全局导航外，不同页面中仍然需要布局导航，如左边固定导航，右边显示内容。

### 如何嵌套：
- 先了解加载顺序。
    _Layout先加载当前路径，然后是Shared目录。

- 默认行为:
    Shared目录下的_Layout，作用于全局，并且在 _ViewStart.cshtml会默认全局使用该布局。通常用来显示整体导航条内容。

- 嵌套实现:
    1. 在当前文件夹，比如/Views/Blog下新建 _BlogLayout.cshtml，不要与全局的布局文件名重名。然后在其中指定使用全局的布局文件：
    ```razor
    @{
        Layout = "_Layout";
    }
    This is Blog layout!
    @RenderBody()
    ```

    2. 在其他页面中，如/Views/Blog下的index.cshtml中。指定_BlogLayout为布局文件。
    ```razor
    @{
        Layout = "_BlogLayout";
    }
    ```
    然后你就会同时看到两个布局都生效了。


### 解释：
由于我们指定了布局的文件名，所以会加载_BlogLayout布局。页面内容会填充@RenderBody()。而在_BlogLayout中，我们又指定了使用默认布局，同理，该布局页面又加载渲染全局布局，将内容显示在布局文件中的@RenderBody处。从而实现了Layout的嵌套使用。
