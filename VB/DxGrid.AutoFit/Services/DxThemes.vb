Imports DevExpress.Blazor

Namespace DxGrid.AutoFit.Services

    Public Module DxThemes

        Public ReadOnly FluentLight As ITheme = Themes.Fluent.Clone(AddressOf AddFluentTheme)

        Public ReadOnly FluentDark As ITheme = Themes.Fluent.Clone(Function(properties)
            properties.Mode = ThemeMode.Dark
            AddFluentTheme(properties)
        End Function)

        Public ReadOnly BlazingBerry As ITheme = Themes.BlazingBerry.Clone(AddressOf AddBootstrapTheme)

        Public ReadOnly BlazingDark As ITheme = Themes.BlazingDark.Clone(AddressOf AddBootstrapTheme)

        Public ReadOnly Purple As ITheme = Themes.Purple.Clone(AddressOf AddBootstrapTheme)

        Public ReadOnly OfficeWhite As ITheme = Themes.OfficeWhite.Clone(AddressOf AddBootstrapTheme)

        Public ReadOnly Bootstrap As ITheme = Themes.BootstrapExternal.Clone(Function(properties) AddBootstrapExternalTheme("bootstrap", properties))

        Public ReadOnly BootstrapDark As ITheme = Themes.BootstrapExternal.Clone(Function(properties) AddBootstrapExternalTheme("bootstrap-dark", properties))

        Public Sub AddBootstrapTheme(ByVal properties As ThemeProperties)
            properties.AddFilePaths($"css/theme-bs.css")
        End Sub

        Public Sub AddBootstrapExternalTheme(ByVal themeName As String, ByVal properties As ThemeProperties)
            properties.Name = themeName
            DxThemes.AddBootstrapTheme(properties)
            properties.AddFilePaths($"css/bootstrap/bootstrap.min.css")
        End Sub

        Public Sub AddFluentTheme(ByVal properties As ThemeProperties)
            properties.AddFilePaths($"css/theme-fluent.css")
        End Sub
    End Module

    Public Class DxThemesService

        Private _ActiveTheme As ITheme

        Public Sub New()
            ActiveTheme = FluentLight
        End Sub

        Public Property ActiveTheme As ITheme
            Get
                Return _ActiveTheme
            End Get

            Private Set(ByVal value As ITheme)
                _ActiveTheme = value
            End Set
        End Property

        Public ReadOnly Property IsFluentActive As Boolean
            Get
                Return ActiveTheme Is FluentLight OrElse ActiveTheme Is FluentDark
            End Get
        End Property

        Public ReadOnly Property IsBootstrapDarkActive As Boolean
            Get
                Return ActiveTheme Is BootstrapDark
            End Get
        End Property

        Public ReadOnly Property IsFluentDarkModeActive As Boolean
            Get
                Return ActiveTheme Is FluentDark
            End Get
        End Property

        Public ReadOnly Property IsActiveThemeDark As Boolean
            Get
                Return IsBootstrapDarkActive OrElse IsFluentDarkModeActive
            End Get
        End Property
    End Class
End Namespace
