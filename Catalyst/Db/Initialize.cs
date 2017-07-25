using System;
using System.Collections.Generic;
using System.Data.Entity;
using Catalyst.Models;
using System.Diagnostics;

namespace Catalyst.Db
{
	public class Initialize
		: DropCreateDatabaseAlways<CatalystContext>
	{
		/// <summary>
		/// Seed a new db with data
		/// </summary>
		/// <param name="db">DbContext to use</param>
		protected override void 
		Seed(
			CatalystContext db)
		{
			Debug.WriteLine("Re-Seeding database...");
			
			//todo, catch errors
			var repoPerson = new ServicePerson(db);
			repoPerson.CreateAll(Initialize.ExamplePersons());

			//todo, catch errors
			var repoPict = new ServicePicture(db);
			repoPict.CreateAll(Initialize.ExamplePictures());

			Debug.WriteLine("Seeding complete...");
		}



		/// static methods

		/// <summary>
		/// Get example data for persons
		/// </summary>
		/// <returns>Collection of Persion</returns>
		public static List<Person>
		ExamplePersons()
		{
			return new List<Person>
			{
				//note: id's are provided for unit testing convenience, they are actually handled by db
				new Person{id = 1, firstName = "Alan", lastName = "McCoy", birthDate = DateParseMicro("1974-07-06 21:43:21"), address = "7848 Ash Dr, Pasadena, Connecticut 33529", interest = "baseball, dancing"},
				new Person{id = 2, firstName = "Paula", lastName = "Aguilar", birthDate = DateParseMicro("1966-10-10 15:07:03"), address = "3763 Calle de Argumosa, Pontevedra, Galicia 31706", interest = "computers, baseball"},
				new Person{id = 3, firstName = "Howard", lastName = "Graham", birthDate = DateParseMicro("1982-11-29 16:35:40"), address = "3254 The Drive, Wells, Durham Q4D 3AB", interest = "cars, biking"},
				new Person{id = 4, firstName = "Jorge", lastName = "Marin", birthDate = DateParseMicro("1954-01-01 08:55:01"), address = "9211 Avenida de Castilla, Málaga, País Vasco 48802", interest = "aerobics, cheeses"},
				new Person{id = 5, firstName = "Benjamin", lastName = "Johansen", birthDate = DateParseMicro("1977-05-31 01:33:44"), address = "1663 Nyvangsvej, Odense Sv, Nordjylland 94993", interest = "running, skiing"},
				new Person{id = 6, firstName = "Clara", lastName = "Hansen", birthDate = DateParseMicro("1948-09-17 07:32:29"), address = "9643 Randersvej, Stenderup, Danmark 71266", interest = "video games, music"},
				new Person{id = 7, firstName = "Ismael", lastName = "Rodriguez", birthDate = DateParseMicro("1967-08-08 07:58:52"), address = "8963 Calle de Arganzuela, Torrejón de Ardoz, Galicia 96717", interest = "dogs, water skiing"},
				new Person{id = 8, firstName = "Frederikke", lastName = "Thomsen", birthDate = DateParseMicro("1962-03-03 09:46:50"), address = "3123 Søndervej, V.Skerninge, Sjælland 51414", interest = "music"},
				new Person{id = 9, firstName = "Esperanza", lastName = "Saez", birthDate = DateParseMicro("1989-07-14 05:57:00"), address = "3328 Calle Mota, Valladolid, Comunidad Valenciana 96994", interest = "skiing, biking"},
				new Person{id = 10, firstName = "Kathy", lastName = "Douglas", birthDate = DateParseMicro("1994-01-06 10:56:19"), address = "9537 Church Road, Cardiff, County Armagh PD7 1PE", interest = "chess, music"},
				new Person{id = 11, firstName = "Barry", lastName = "Perkins", birthDate = DateParseMicro("1977-10-19 06:00:27"), address = "5837 Daisy Dr, Clarksville, Mississippi 51654", interest = "cheeses, kernels"},
				new Person{id = 12, firstName = "Christina", lastName = "Porter", birthDate = DateParseMicro("1990-03-23 02:06:04"), address = "3093 Church Lane, Bangor, Powys RX4 8ZZ", interest = "ice skating, writing"},
				new Person{id = 13, firstName = "Lily", lastName = "Dean", birthDate = DateParseMicro("1989-11-11 05:01:56"), address = "6963 W Sherman Dr, Manchester, Nevada 76320", interest = "water skiing, dancing"},
				new Person{id = 14, firstName = "Gustavo", lastName = "Castro", birthDate = DateParseMicro("1948-11-23 12:28:03"), address = "559 Calle del Pez, Zaragoza, Castilla y León 62971", interest = "cards, baseball"},
				new Person{id = 15, firstName = "Carlos", lastName = "Garcia", birthDate = DateParseMicro("1990-01-24 06:49:5"), address = "5413 Calle de Tetuán, Zaragoza, Canarias 23194", interest = "shopping, dogs"},
				new Person{id = 16, firstName = "Dan", lastName = "Willis", birthDate = DateParseMicro("1948-01-08 07:56:47"), address = "7321 Kingsway, Newcastle Upon Tyne, Central CW3 2XD", interest = "computers, skiing"},
				new Person{id = 17, firstName = "Mitchell", lastName = "Garrett", birthDate = DateParseMicro("1962-08-20 23:52:17"), address = "1249 Green Lane, Carlisle, Buckinghamshire B9 9ZY", interest = "biking, camping"},
				new Person{id = 18, firstName = "Emma", lastName = "Andersen", birthDate = DateParseMicro("1962-04-11 21:27:49"), address = "1684 Enggårdsvej, Nr åby, Sjælland 81815", interest = "cars, chocolate"},
				new Person{id = 19, firstName = "Angel", lastName = "Hidalgo", birthDate = DateParseMicro("1987-05-20 00:44:46"), address = "2273 Calle de Bravo Murillo, Barcelona, Melilla 53441", interest = "cheeses, camping"},
				new Person{id = 20, firstName = "Diana", lastName = "Horton", birthDate = DateParseMicro("1993-04-27 03:51:55"), address = "9928 Central St, Costa Mesa, Massachusetts 49571", interest = "fishing, chess"},

/*
				new Person{id = 1, firstName = "Carson", lastName = "Alexander", birthDate = DateParseMicro("1985-09-01"), address = "", interest = ""},
				new Person{id = 2, firstName = "Meredith", lastName = "Alonso", birthDate = DateParseMicro("1972-09-01")},
				new Person{id = 3, firstName = "Arturo", lastName = "Anand", birthDate = DateParseMicro("1968-09-01")},
				new Person{id = 4, firstName = "Gytis", lastName = "Barzdukas", birthDate = DateParseMicro("1990-09-01")},
				new Person{id = 5, firstName = "Yan", lastName = "Li", birthDate = DateParseMicro("2002-09-01")},
				new Person{id = 6, firstName = "Peggy", lastName = "Justice", birthDate = DateParseMicro("1981-09-01")},
				new Person{id = 7, firstName = "Laura", lastName = "Norman", birthDate = DateParseMicro("1982-09-01")},
				new Person{id = 8, firstName = "Nino", lastName = "Olivetto", birthDate = DateParseMicro("1998-09-01")}
*/
			};
		}


		/// <summary>
		/// Get example data for pictures
		/// </summary>
		/// <returns>Collection of Picture</returns>
		public static List<Picture>
		ExamplePictures()
		{
			return new List<Picture>
			{
				//note: id's are provided for unit testing convenience, they are actually handled by db
				//note: pitcure.id and person.id happen to match, but we'll avoid that assumption
				new Picture {id = 1, mimeType = "image/jpeg", size = 3598, path="/content/face/1.jpg", personId = 1},
				new Picture {id = 2, mimeType = "image/jpeg", size = 5157, path="/content/face/2.jpg", personId = 2},
				new Picture {id = 3, mimeType = "image/jpeg", size = 5631, path="/content/face/3.jpg", personId = 3},
				new Picture {id = 4, mimeType = "image/jpeg", size = 6336, path="/content/face/4.jpg", personId = 4},
				new Picture {id = 5, mimeType = "image/jpeg", size = 3249, path="/content/face/5.jpg", personId = 5},
				new Picture {id = 6, mimeType = "image/jpeg", size = 6492, path="/content/face/6.jpg", personId = 6},
				new Picture {id = 7, mimeType = "image/jpeg", size = 4988, path="/content/face/7.jpg", personId = 7},
				new Picture {id = 8, mimeType = "image/jpeg", size = 5352, path="/content/face/8.jpg", personId = 8},
				new Picture {id = 9, mimeType = "image/jpeg", size = 5522, path="/content/face/9.jpg", personId = 9},
				new Picture {id = 10, mimeType = "image/jpeg", size = 3965, path="/content/face/10.jpg", personId = 10},
				new Picture {id = 11, mimeType = "image/jpeg", size = 5728, path="/content/face/11.jpg", personId = 11},
				new Picture {id = 12, mimeType = "image/jpeg", size = 4067, path="/content/face/12.jpg", personId = 12},
				new Picture {id = 13, mimeType = "image/jpeg", size = 5071, path="/content/face/13.jpg", personId = 13},
				new Picture {id = 14, mimeType = "image/jpeg", size = 6741, path="/content/face/14.jpg", personId = 14},
				new Picture {id = 15, mimeType = "image/jpeg", size = 3805, path="/content/face/15.jpg", personId = 15},
				new Picture {id = 16, mimeType = "image/jpeg", size = 5973, path="/content/face/16.jpg", personId = 16},
				new Picture {id = 17, mimeType = "image/jpeg", size = 3200, path="/content/face/17.jpg", personId = 17},
				new Picture {id = 18, mimeType = "image/jpeg", size = 2881, path="/content/face/18.jpg", personId = 18},
				new Picture {id = 19, mimeType = "image/jpeg", size = 3473, path="/content/face/19.jpg", personId = 19},
				new Picture {id = 20, mimeType = "image/jpeg", size = 5900, path="/content/face/20.jpg", personId = 20}
			};
		}



		/// private methods

		/// <summary>
		/// Parse a date string into JSON compatible unix UTC milliseconds
		/// </summary>
		private static long
		DateParseMicro(
			string date)
		{
			return new DateTimeOffset(DateTime.Parse(date)).ToUnixTimeMilliseconds();
		}
	}
}