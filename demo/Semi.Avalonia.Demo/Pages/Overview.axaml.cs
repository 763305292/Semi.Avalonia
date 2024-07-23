using Avalonia.Controls;

namespace Semi.Avalonia.Demo.Pages;

public partial class Overview : UserControl
{
    public Overview()
    {
        InitializeComponent();
    }

    public string MainInstall { get; set; } = "dotnet add package Semi.Avalonia --version 11.1.0";

    public string MainStyle { get; set; } =
        """
        <Application.Styles>
        <!-- You can still reference in old way.  -->
        <!-- <StyleInclude Source="avares://Semi.Avalonia/Themes/Index.axaml" /> -->
            <semi:SemiTheme Locale="zh-cn" />
        </Application.Styles>
        """;

    public string ColorPickerInstall { get; set; } = "dotnet add package Semi.Avalonia.ColorPicker --version 11.1.0";

    public string ColorPickerStyle { get; set; } =
        """
        <Application.Styles>
            <StyleInclude Source="avares://Semi.Avalonia.ColorPicker/Index.axaml" />
        </Application.Styles>
        """;

    public string DataGridInstall { get; set; } = "dotnet add package Semi.Avalonia.DataGrid --version 11.1.0";

    public string DataGridStyle { get; set; } =
        """
        <Application.Styles>
            <StyleInclude Source="avares://Semi.Avalonia.DataGrid/Index.axaml" />
        </Application.Styles>
        """;

    public string TreeDataGridInstall { get; set; } = "dotnet add package Semi.Avalonia.TreeDataGrid --version 11.1.0";

    public string TreeDataGridStyle { get; set; } =
        """
        <Application.Styles>
            <StyleInclude Source="avares://Semi.Avalonia.TreeDataGrid/Index.axaml" />
        </Application.Styles>
        """;
}