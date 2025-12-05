using DxGrid.AutoFit.Models;

namespace DxGrid.AutoFit.Services
{
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
}