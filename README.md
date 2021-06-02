### About us

> &nbsp; :adult: __James Lee__ &nbsp;&nbsp; [Github](https://github.com/devncore-james) &nbsp;&nbsp; james.lee@devncore.org  
> &nbsp; :woman: __Elena Kim__ &nbsp;&nbsp; [Github](https://github.com/devncore-elena) &nbsp;&nbsp; elena.kim@devncore.org

We are very ordinary developers, so we need to communicate with you.   
You can always share information with us and we are looking forward to it.  

##### _Open Source &nbsp; https://github.com/devncore/devncore   &nbsp;&nbsp;   Official Website &nbsp; https://devncore.org_ 

### License Policy
[![MIT license](https://img.shields.io/badge/License-MIT-blue.svg)](https://lbesson.mit-license.org/)
[![GPLv3 license](https://img.shields.io/badge/License-GPLv3-blue.svg)](http://perso.crans.org/besson/LICENSE.html)

***

## ICommander

|Namespace|Assembly|
|:--------:|:-------:|
|`System.Windows.Data`|`PresentationFramework.dll`|

Value converters provides a way to apply custom logic to a [binding](https://github.com/devncore/wpf-xaml-binding).  
When source object type and target object type are different, value converters act like middlemen.  
Converter class must implement **IValueConverter** interface, which consists of two methods, `Convert()` and `ConvertBack()`.

_**Convert** method gets called when source updates target object._
```c#
public object Convert (object value, Type targetType, object parameter, CultureInfo culture);

// parameters:
//   value: The value produced by the binding source.
//   targetType: The type of the binding target property.
//   parameter: The converter parameter to use.
//   culture: The culture to use in the converter.
// return:
//   A converted value. If the method returns null, the valid null value is used.
```  

_**ConvertBack** method gets called when target updates source object._
```c#
public object ConvertBack (object value, Type targetType, object parameter, CultureInfo culture);

// parameters:
//   value: The value that is produced by the binding target.
//   targetType: The type to convert to.
//   parameter: The converter parameter to use.
//   culture: The culture to use in the converter.
// return:
//   A converted value. If the method returns null, the valid null value is used.
```  
***

## Sample
#### :point_right: [Download](https://github.com/devncore/ivalueconverter/archive/refs/heads/main.zip)  

<img src="https://user-images.githubusercontent.com/74305823/117662030-0f24f800-b1da-11eb-8f97-327c3d419756.png" width="500"/>

### :pushpin: BooleanToVisibilityConverter
##### `Converter.cs`
```c#
public class BooleanToVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value.Equals(true) ? Visibility.Visible : Visibility.Collapsed;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
```
##### `Namespace`
```xaml
xmlns:cvt="clr-namespace:IValueConverterSample.Converters"
```

##### `Resource`
```xaml
<cvt:BooleanToVisibilityConverter x:Key="BooleanToVisibilityConverter"/>
```
##### `Style`
```xaml
<Style TargetType="{x:Type TextBlock}" x:Key="TXB.HELLO">
    <Setter Property="Grid.Row" Value="0"/>
    <Setter Property="Text" Value="Hello!"/>
    <Setter Property="Foreground" Value="#EFE6D4"/>
    <Setter Property="FontWeight" Value="Bold"/>
    <Setter Property="FontSize" Value="18"/>
    <Setter Property="HorizontalAlignment" Value="Left"/>
    <Setter Property="Margin" Value="100 22 0 0"/>
    <Setter Property="Visibility" Value="{Binding ElementName=tgl, Path=IsChecked, 
  	  				  Converter={StaticResource BooleanToVisibilityConverter}}"/>
</Style>
```
##### `Result`

<table>
    <thead>
        <tr>
            <th>'IsChecked' = true</th>
            <th>'IsChecked' = false</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td align="center">
                <img src="https://user-images.githubusercontent.com/74305823/116886059-949d2b00-ac63-11eb-9885-725f440d7cd2.png" width="150"/>
            </td>
            <td align="center">
                <img src="https://user-images.githubusercontent.com/74305823/116886656-4b99a680-ac64-11eb-8b89-4d6945cd5306.png" width="150"/>
            </td>
        </tr>
    </tbody>
</table>

<br />

### :pushpin: StringFormatConverter
##### `Converter.cs`
```csharp
public class StringFormatConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return string.Format("{0:N0}%", value);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
```
##### `Namespace`
```xaml
xmlns:cvt="clr-namespace:IValueConverterSample.Converters"
```

##### `Resource`
```xaml
<cvt:StringFormatConverter x:Key="StringFormatConverter"/>
```

##### `Style`
```xaml
<Style TargetType="{x:Type TextBlock}" x:Key="IN.CONTENT">
    <Setter Property="Grid.Column" Value="1"/>
    <Setter Property="Foreground" Value="#9B9688"/>
    <Setter Property="FontSize" Value="13"/>
    <Setter Property="FontWeight" Value="Bold"/>
    <Setter Property="HorizontalAlignment" Value="Left"/>
    <Setter Property="VerticalAlignment" Value="Center"/>
    <Setter Property="Margin" Value="10 20 0 0"/>
    <Setter Property="Text" Value="{Binding ElementName=slider2, Path=Value, 
                                            Converter={StaticResource StringFormatConverter}}"/>
</Style>
```

##### `Result`
<img src="https://user-images.githubusercontent.com/74305823/116886718-610ed080-ac64-11eb-9c08-8c48a28c63e9.png" width="400"/>

<br />

### :pushpin: MultiValueConverter
##### `Converter.cs`
```csharp
public class MultiValueBooleanConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        return ((bool)values[0] == true && !string.IsNullOrWhiteSpace(values[1]?.ToString()));
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
```

##### `Namespace`
```xaml
xmlns:cvt="clr-namespace:IValueConverterSample.Converters"
```

##### `Resource`
```xaml
<cvt:MultiValueBooleanConverter x:Key="MultiValueBooleanConverter"/>
```

##### `Style`
```xaml
<Style TargetType="{x:Type ToggleButton}" x:Key="TGL.ACCEPT" BasedOn="{StaticResource TGL.BASE}">
    ...
    <Setter Property="IsEnabled">
        <Setter.Value>
            <MultiBinding Converter="{StaticResource MultiValueBooleanConverter}">
                <Binding ElementName="rdo1" Path="IsChecked"/>
                <Binding ElementName="txt" Path="Text"/>
            </MultiBinding>
        </Setter.Value>
    </Setter>
</Style>
```

##### `Result`

<table>
    <thead>
        <tr>
            <th>'IsEnabled' = true</th>
            <th>'IsEnabled' = false</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td align="center">
                <img src="https://user-images.githubusercontent.com/74305823/116887455-49841780-ac65-11eb-80be-f7908e63d214.png" width="400"/>
            </td>
            <td align="center">
                <img src="https://user-images.githubusercontent.com/74305823/116887338-2c4f4900-ac65-11eb-915e-d7231bacc1d1.png" width="400"/>
            </td>
        </tr>
    </tbody>
</table>
<br />

### :pushpin: FileSizeToFormatConverter
##### `Converter.cs`
```c#
public class FileSizeToFormatConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        string[] sizes = { "B", "KB", "MB", "GB", "TB" };
        long len = 0;
        if (value.ToString() != "")
        {
            len = long.Parse(value.ToString());
        }

        int order = 0;
        while (len >= 1024 && order < sizes.Length - 1)
        {
            order++;
            len = len / 1024;
        }

        // Adjust the format string to your preferences. For example "{0:0.#}{1}" would
        // show a single decimal place, and no space.
        return String.Format("({0:0.##} {1})", len, sizes[order]);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
```

##### `Namespace`
```xaml
xmlns:cvt="clr-namespace:IValueConverterSample.Converters"
```

##### `Resource`
```xaml
<cvt:FileSizeToFormatConverter x:Key="FileSizeToFormatConverter"/>
```

##### `Style`
```xaml
<Grid>
    <Grid.ColumnDefinitions>
	    <ColumnDefinition Width="*"/>
	    <ColumnDefinition Width="Auto"/>
    </Grid.ColumnDefinitions>
    <TextBlock Grid.Column="0" Text="{Binding Name}"/>
    <TextBlock Grid.Column="1" Text="{Binding Length, Converter={StaticResource FileSizeToFormatConverter}}"/>
</Grid>
```

##### `Result`
<img src="https://user-images.githubusercontent.com/74305823/117662606-b4d86700-b1da-11eb-8eae-f5af7183bdc4.png" width="350"/>  
<br />

***

## Reference
[:bookmark_tabs:](https://www.codeproject.com/Tips/868163/IValueConverter-Example-and-Usage-in-WPF) **CODE PROJECT** &nbsp; <ins>IValueConverter Example and Usage in WPF</ins>  
[:bookmark_tabs:](https://docs.microsoft.com/en-ca/dotnet/api/system.windows.data.ivalueconverter?view=net-5.0) **Microsoft Docs** &nbsp; <ins>IValueConverter Interface</ins>  
[:bookmark_tabs:](https://www.wpf-tutorial.com/data-binding/value-conversion-with-ivalueconverter/) **WPF Tutorial** &nbsp; <ins>Value conversion with IValueConverter</ins>
