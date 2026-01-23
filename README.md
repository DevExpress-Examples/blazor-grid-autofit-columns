<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/1109763278/25.1.7%2B)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
# DxGrid - How to implement the AutoFit feature for grids with different column widths

This example illustrates how to use the [AutoFitColumnWidths()](https://docs.devexpress.com/Blazor/DevExpress.Blazor.DxGrid.AutoFitColumnWidths) for grids that have columns with varying widths such that no columns will be truncated.
<img width="970" height="490" alt="image" src="https://github.com/user-attachments/assets/32541fcf-97fd-4407-9bab-661b9794dbe4" />
<img width="970" height="490" alt="image" src="https://github.com/user-attachments/assets/34764617-61db-45a8-86e8-92d162f613a6" />

## Implementation Details
1. Add DxGrid and bind it to data that contains properties of predictable length (e.g. ID, First Name, Honorific) and unpredictable length (e.g. Email, Address):
 ```razor
<DxGrid @ref=Grid Data="@people" TextWrapEnabled=false CssClass="my-grid">
  <Columns>
    <DxGridDataColumn FieldName="Id" Caption="ID" />
    <DxGridDataColumn FieldName="FirstName" Caption="First Name" />
    <DxGridDataColumn FieldName="LastName" Caption="Last Name" />
    <DxGridDataColumn FieldName="Honorific" Caption="Honorific" />
    <DxGridDataColumn FieldName="Email" Caption="Email" />
    <DxGridDataColumn FieldName="Address" Caption="Address" />
    <DxGridDataColumn FieldName="Occupation" Caption="Occupation" />
    <DxGridDataColumn FieldName="Description" Caption="Description" />
  </Columns>
</DxGrid>

@code {
  IGrid Grid { get; set; }
  private List<Person> people { get; set; }

  protected override void OnInitialized()
  {
    people = PersonDataService.GetPeople();
  }
}
 ```
 ```csharp
public class Person
{
  public int Id { get; set; }
  public string FirstName { get; set; }
  public string LastName { get; set; }
  public string Honorific { get; set; }
  public string Email { get; set; }
  public string Address { get; set; }
  public string Occupation { get; set; }
  public string Description { get; set; }
}
```
```csharp
public class PersonDataService : IPersonDataService
{
  public List<Person> GetPeople()
  {
    return new List<Person>() {
      new Person { Id = 1, FirstName = "Alice", LastName = "Johnson", Honorific = "Ms.", Email = "alice.johnson@example.com", Address = "123 Maple Street, Springfield", Occupation = "Engineer", Description = "Enjoys solving complex problems and creating elegant solutions." },
      new Person { Id = 2, FirstName = "Bob", LastName = "Smith", Honorific = "Mr.", Email = "bob.smith@example.com", Address = "456 Oak Avenue, Rivertown", Occupation = "Teacher", Description = "Passionate about education and lifelong learning." },
      new Person { Id = 3, FirstName = "Catherine", LastName = "Lee", Honorific = "Dr.", Email = "catherine.lee@example.com", Address = "789 Pine Road, Lakeside", Occupation = "Physician", Description = "Dedicated to patient care and medical research." },
      new Person { Id = 4, FirstName = "David", LastName = "Martinez", Honorific = "Mr.", Email = "david.martinez@example.com", Address = "321 Birch Lane, Hillcrest", Occupation = "Architect", Description = "Designs sustainable and innovative buildings." },
      new Person { Id = 5, FirstName = "Ella", LastName = "Brown", Honorific = "Mrs.", Email = "ella.brown@example.com", Address = "654 Cedar Court, Brookfield", Occupation = "Marketing", Description = "Creative thinker with a knack for brand strategy." },
      new Person { Id = 6, FirstName = "Frank", LastName = "Wilson", Honorific = "Mr.", Email = "frank.wilson@example.com", Address = "987 Walnut Drive, Greenfield", Occupation = "Chef", Description = "Loves experimenting with flavors and cuisines." },
      new Person { Id = 7, FirstName = "Grace", LastName = "Taylor", Honorific = "Ms.", Email = "grace.taylor@example.com", Address = "159 Elm Street, Fairview", Occupation = "Designer", Description = "Passionate about visual storytelling and design." },
      new Person { Id = 8, FirstName = "Henry", LastName = "Clark", Honorific = "Mr.", Email = "henry.clark@example.com", Address = "753 Willow Way, Meadowbrook", Occupation = "Lawyer", Description = "Focused on justice and advocacy for clients." },
      new Person { Id = 9, FirstName = "Isabella", LastName = "Davis", Honorific = "Ms.", Email = "isabella.davis@example.com", Address = "852 Cherry Boulevard, Sunnyside", Occupation = "Journalist", Description = "Enjoys uncovering stories and sharing truth." },
      new Person { Id = 10, FirstName = "Jack", LastName = "Miller", Honorific = "Mr.", Email = "jack.miller@example.com", Address = "951 Poplar Street, Crestwood", Occupation = "Entrepreneur", Description = "Driven by innovation and building new ventures." }
    };
  }
}
```
2. In OnAfterRender, call [Grid.BeginUpdate()](https://docs.devexpress.com/Blazor/DevExpress.Blazor.DxGrid.BeginUpdate) and loop through each column using [Grid.GetColumns()](https://docs.devexpress.com/Blazor/DevExpress.Blazor.DxGrid.GetColumns):
```csharp
protected override void OnAfterRender(bool firstRender)
{
   if (firstRender)
   {
       Grid.BeginUpdate();
       foreach (var column in Grid.GetColumns())
```   
3. For columns that have unpredictable length, set the column [Width](https://docs.devexpress.com/Blazor/DevExpress.Blazor.DxGridColumn.Width) to `0px`. For columns that have a predictable length, set the column [MinWidth](https://docs.devexpress.com/Blazor/DevExpress.Blazor.DxGridColumn.MinWidth) to a value that will not truncate the text in the columns (in this case, `100px`):
```csharp
Grid.BeginUpdate();
foreach (var column in Grid.GetColumns())
{
    if (column.Caption == "Email" || column.Caption == "Address" || column.Caption == "Description")
    {
        column.Width = "0px";
    }
    else
    {
        column.MinWidth = 100;
    }
}
```
4. After updating the Width or MinWidth of each column, call [Grid.EndUpdate()](https://docs.devexpress.com/Blazor/DevExpress.Blazor.DxGrid.EndUpdate) and [Grid.AutoFitColumnWidths()](https://docs.devexpress.com/Blazor/DevExpress.Blazor.DxGrid.AutoFitColumnWidths):
```csharp
protected override void OnAfterRender(bool firstRender)
{
    if (firstRender)
    {
        Grid.BeginUpdate();
        foreach (var column in Grid.GetColumns())
        {
            if (column.Caption == "Email" || column.Caption == "Address" || column.Caption == "Description")
            {
                column.Width = "0px";
            }
            else
            {
                column.MinWidth = 100;
            }
        }
        Grid.EndUpdate();

        Grid.AutoFitColumnWidths();
    }
}
```

## Files to Review

- [Index.razor](https://github.com/DevExpress-Examples/draft-DxGrid-AutoFit-Example/blob/25.1.7%2B/CS/DxGrid.AutoFit/Components/Pages/Index.razor)
- [Person.cs](https://github.com/DevExpress-Examples/draft-DxGrid-AutoFit-Example/blob/25.1.7%2B/CS/DxGrid.AutoFit/Models/Person.cs)
- [PersonDataService.cs](https://github.com/DevExpress-Examples/draft-DxGrid-AutoFit-Example/blob/25.1.7%2B/CS/DxGrid.AutoFit/Services/PersonDataService.cs)

<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=draft-DxGrid-AutoFit-Example&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=draft-DxGrid-AutoFit-Example&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
