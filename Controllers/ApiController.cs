using Microsoft.AspNetCore.Mvc;
using OLMServer.Libraries;
using OLMServer.OLMData;

namespace OLMServer.Controllers
{
    [Route("/api")]
    public class ApiController : Controller
    {
        [HttpGet("")]
        public ActionResult Index()
        {
            return new ContentResult()
            {
                ContentType = "text/html",
                Content = ""
            };
        }

        string[] countries = new string[] {
            "Afghanistan",
            "Albania",
            "Algeria",
            "Andorra",
            "Angola",
            "Antigua & Deps",
            "Argentina",
            "Armenia",
            "Australia",
            "Austria",
            "Azerbaijan",
            "Bahamas",
            "Bahrain",
            "Bangladesh",
            "Barbados",
            "Belarus",
            "Belgium",
            "Belize",
            "Benin",
            "Bermuda",
            "Bhutan",
            "Bolivia",
            "Bosnia Herzegovina",
            "Botswana",
            "Brazil",
            "Brunei",
            "Bulgaria",
            "Burkina",
            "Burundi",
            "Cambodia",
            "Cameroon",
            "Canada",
            "Cape Verde",
            "Central African Rep",
            "Chad",
            "Chile",
            "China",
            "Colombia",
            "Comoros",
            "Congo",
            "Congo (Democratic Rep)",
            "Costa Rica",
            "Croatia",
            "Cuba",
            "Cyprus",
            "Czech Republic",
            "Denmark",
            "Djibouti",
            "Dominica",
            "Dominican Republic",
            "East Timor",
            "Ecuador",
            "Egypt",
            "El Salvador",
            "Equatorial Guinea",
            "Eritrea",
            "Estonia",
            "Eswatini",
            "Ethiopia",
            "Fiji",
            "Finland",
            "France",
            "Gabon",
            "Gambia",
            "Georgia",
            "Germany",
            "Ghana",
            "Greece",
            "Grenada",
            "Guatemala",
            "Guinea",
            "Guinea-Bissau",
            "Guyana",
            "Haiti",
            "Honduras",
            "Hungary",
            "Iceland",
            "India",
            "Indonesia",
            "Iran",
            "Iraq",
            "Ireland (Republic)",
            "Israel",
            "Italy",
            "Ivory Coast",
            "Jamaica",
            "Japan",
            "Jordan",
            "Kazakhstan",
            "Kenya",
            "Kiribati",
            "Korea North",
            "Korea South",
            "Kosovo",
            "Kuwait",
            "Kyrgyzstan",
            "Laos",
            "Latvia",
            "Lebanon",
            "Lesotho",
            "Liberia",
            "Libya",
            "Liechtenstein",
            "Lithuania",
            "Luxembourg",
            "Macedonia",
            "Madagascar",
            "Malawi",
            "Malaysia",
            "Maldives",
            "Mali",
            "Malta",
            "Marshall Islands",
            "Mauritania",
            "Mauritius",
            "Mexico",
            "Micronesia",
            "Moldova",
            "Monaco",
            "Mongolia",
            "Montenegro",
            "Morocco",
            "Mozambique",
            "Myanmar",
            "Namibia",
            "Nauru",
            "Nepal",
            "Netherlands",
            "New Zealand",
            "Nicaragua",
            "Niger",
            "Nigeria",
            "Norway",
            "Oman",
            "Pakistan",
            "Palau",
            "Palestine",
            "Panama",
            "Papua New Guinea",
            "Paraguay",
            "Peru",
            "Philippines",
            "Poland",
            "Portugal",
            "Qatar",
            "Romania",
            "Russian Federation",
            "Rwanda",
            "St Kitts & Nevis",
            "St Lucia",
            "Saint Vincent & the Grenadines",
            "Samoa",
            "San Marino",
            "Sao Tome & Principe",
            "Saudi Arabia",
            "Senegal",
            "Serbia",
            "Seychelles",
            "Sierra Leone",
            "Singapore",
            "Slovakia",
            "Slovenia",
            "Solomon Islands",
            "Somalia",
            "South Africa",
            "South Sudan",
            "Spain",
            "Sri Lanka",
            "Sudan",
            "Suriname",
            "Sweden",
            "Switzerland",
            "Syria",
            "Taiwan",
            "Tajikistan",
            "Tanzania",
            "Thailand",
            "Togo",
            "Tonga",
            "Trinidad & Tobago",
            "Tunisia",
            "Turkey",
            "Turkmenistan",
            "Tuvalu",
            "Uganda",
            "Ukraine",
            "United Arab Emirates",
            "United Kingdom",
            "United States",
            "Uruguay",
            "Uzbekistan",
            "Vanuatu",
            "Vatican City",
            "Venezuela",
            "Vietnam",
            "Yemen",
            "Zambia",
            "Zimbabwe",
        };

        string[] books = new string[] {
            "Romeo and Juliet by William Shakespeare (6759)",
            "A Room with a View by E. M. Forster (5737)",
            "Middlemarch by George Eliot (5608)",
            "Little Women; Or, Meg, Jo, Beth, and Amy by Louisa May Alcott(5260)",
            "The Enchanted April by Elizabeth Von Arnim(5110)",
            "The Blue Castle: a novel by L.M.Montgomery(4981)",
            "The Complete Works of William Shakespeare by William Shakespeare(4961)",
            "Moby Dick; Or, The Whale by Herman Melville(4938)",
            "Cranford by Elizabeth Cleghorn Gaskell(4837)",
            "The Adventures of Ferdinand Count Fathom — Complete by T.Smollett(4837)",
            "The Expedition of Humphry Clinker by T.Smollett(4724)",
            "The Adventures of Roderick Random by T.Smollett(4691)",
            "History of Tom Jones, a Foundling by Henry Fielding(4439)",
            "My Life — Volume 1 by Richard Wagner(4313)",
            "Twenty Years After by Alexandre Dumas(4302)",
            "Frankenstein; Or, The Modern Prometheus by Mary Wollstonecraft Shelley(3080)",
            "Pride and Prejudice by Jane Austen(2361)",
            "Alice's Adventures in Wonderland by Lewis Carroll (1065)",
            "The Great Gatsby by F.Scott Fitzgerald(979)",
            "The Picture of Dorian Gray by Oscar Wilde(902)",
            "A Doll's House : a play by Henrik Ibsen (890)",
            "The Yellow Wallpaper by Charlotte Perkins Gilman(854)",
            "Schizophrenic by Noel M.Loomis(850)",
            "The Scarlet Letter by Nathaniel Hawthorne(820)",
            "A Tale of Two Cities by Charles Dickens(818)",
            "The Adventures of Sherlock Holmes by Arthur Conan Doyle(760)",
            "The Souls of Black Folk by W.E.B.Du Bois(758)",
            "A Christmas Carol in Prose; Being a Ghost Story of Christmas by Charles Dickens(750)",
            "Fuzzy-Wuzz, a little brown bear of the Sierras by Allen Chaffee(737)",
            "Dracula by Bram Stoker(702)",
            "The last space ship by Murray Leinster(697)",
            "Great Expectations by Charles Dickens(693)",
            "A Modest Proposal by Jonathan Swift(660)",
            "The foxholes of Mars by Fritz Leiber(660)",
            "The Importance of Being Earnest: A Trivial Comedy for Serious People by Oscar Wilde(646)",
            "Ulysses by James Joyce(634)",
            "Metamorphosis by Franz Kafka(633)",
            "Jane Eyre: An Autobiography by Charlotte Brontë(628)",
            "Leviathan by Thomas Hobbes(623)",
            "The Strange Case of Dr.Jekyll and Mr.Hyde by Robert Louis Stevenson(622)",
            "Noli Me Tangere by José Rizal(587)",
            "Grimms' Fairy Tales by Jacob Grimm and Wilhelm Grimm (557)",
            "Crime and Punishment by Fyodor Dostoyevsky(556)",
            "Adventures of Huckleberry Finn by Mark Twain(536)",
            "The Brothers Karamazov by Fyodor Dostoyevsky(533)",
            "Holly: The Romance of a Southern Girl by Ralph Henry Barbour(531)",
            "The Iliad by Homer(529)",
            "Heart of Darkness by Joseph Conrad(497)",
            "The Prince by Niccolò Machiavelli(462)",
            "War and Peace by graf Leo Tolstoy(454)",
            "The Odyssey by Homer(445)",
            "The Count of Monte Cristo, Illustrated by Alexandre Dumas(418)",
            "Dubliners by James Joyce(416)",
            "The Interesting Narrative of the Life of Olaudah Equiano, Or Gustavus Vassa, The African by Equiano(412)",
            "The Hound of the Baskervilles by Arthur Conan Doyle(412)",
            "The Slang Dictionary: Etymological, Historical and Andecdotal by John Camden Hotten(403)",
            "Narrative of the Life of Frederick Douglass, an American Slave by Frederick Douglass(402)",
            "Walden, and On The Duty Of Civil Disobedience by Henry David Thoreau(394)",
            "Second Treatise of Government by John Locke(391)",
            "A Study in Scarlet by Arthur Conan Doyle(386)",
            "Papa knows best by Wallace Umphrey(381)",
            "The Republic by Plato(380)",
            "Autobiography of Benjamin Franklin by Benjamin Franklin(371)",
            "Anne of Green Gables by L.M.Montgomery(366)",
            "Peter Pan by J.M.Barrie(364)",
            "Dairying exemplified: or, The business of cheese-making, the second edition corrected and improved(363)",
            "Tractatus Logico-Philosophicus by Ludwig Wittgenstein(352)",
            "The Call of the Wild by Jack London(346)",
            "Beowulf: An Anglo-Saxon Epic Poem(345)",
            "Don Quixote by Miguel de Cervantes Saavedra(344)",
            "Little Women by Louisa May Alcott(341)",
            "Winnie-the-Pooh by A.A.Milne(340)",
            "An elementary treatise on electricity by James Clerk Maxwell(339)",
            "The Wonderful Wizard of Oz by L.Frank Baum(333)",
            "The Lady with the Dog and Other Stories by Anton Pavlovich Chekhov(330)",
            "The Tragical History of Doctor Faustus by Christopher Marlowe(329)",
            "Wuthering Heights by Emily Brontë(325)",
            "Candide by Voltaire(317)",
            "How the Other Half Lives: Studies Among the Tenements of New York by Jacob A.Riis(313)",
            "Gulliver's Travels into Several Remote Nations of the World by Jonathan Swift (308)",
            "Treasure Island by Robert Louis Stevenson(305)",
            "Frankenstein; Or, The Modern Prometheus by Mary Wollstonecraft Shelley(301)",
            "Anna Karenina by graf Leo Tolstoy(300)",
            "The Problems of Philosophy by Bertrand Russell(294)",
            "The Romance of Lust: A classic Victorian erotic novel by Anonymous(293)",
            "Simple Sabotage Field Manual by United States.Office of Strategic Services(288)",
            "Incidents in the Life of a Slave Girl, Written by Herself by Harriet A.Jacobs(284)",
            "Thus Spake Zarathustra: A Book for All and None by Friedrich Wilhelm Nietzsche(284)",
            "The War of the Worlds by H.G.Wells(284)",
            "Narrative of the Captivity and Restoration of Mrs.Mary Rowlandson by Mary White Rowlandson (283)",
            "Essays of Michel de Montaigne — Complete by Michel de Montaigne(281)",
            "Beyond Good and Evil by Friedrich Wilhelm Nietzsche(276)",
            "The Jungle by Upton Sinclair(274)",
            "The Adventures of Tom Sawyer, Complete by Mark Twain(271)",
            "The Works of Edgar Allan Poe — Volume 2 by Edgar Allan Poe(267)",
            "The Prophet by Kahlil Gibran(265)",
            "The Time Machine by H.G.Wells(263)",
            "Southern Horrors: Lynch Law in All Its Phases by Ida B.Wells-Barnett (262)",
            "Emma by Jane Austen(258)",
            "Oliver Twist by Charles Dickens(258)"
        };

        [HttpGet("complete")]
        public ActionResult Complete(string q)
        {
            if (string.IsNullOrEmpty(q))
            {
                return new ContentResult()
                {
                    ContentType = "application/json",
                    Content = "[]"
                };
            }


            var booksFromFile = System.IO.File.ReadAllLinesAsync("Public/books.txt");
            var findArray = booksFromFile.Result.ToArray();

            q = q.Trim();
            if (q.StartsWith("ID:"))
            {
                Console.WriteLine("ID");
                var elements = TextProcessing.FindByStart(q.Split(" ")[0].Remove(0, 3), findArray).ToArray();

                string myylist = "[";
                foreach (string str in elements)
                {
                    myylist += $"\"{str.Trim().Remove(0, 5)}\",";
                    Console.WriteLine(str);
                }
                if (myylist.Length > 1)
                {
                    myylist = myylist.Remove(myylist.Length - 1, 1);
                }
                myylist += "]";
                return new ContentResult()
                {
                    ContentType = "application/json",
                    Content = myylist
                };
            }

            var nlst = Libraries.TextProcessing.AutoComplete(q, findArray, 100);

            string lst = "[";
            foreach (string str in nlst)
            {
                lst += $"\"{str.Trim().Remove(0, 5)}\",";
                Console.WriteLine(str);
            }
            if (lst.Length > 1)
            {
                lst = lst.Remove(lst.Length - 1, 1);
            }
            lst += "]";
            return new ContentResult()
            {
                ContentType = "application/json",
                Content = lst
            };
        }

        [HttpPost("addbook")]
        public ActionResult AddBook()
        {
            ProgramData.books.Add(new Book()
            {
                author = new Author(),
                bookSerie = new BookSerie(),
                currentStocks = new List<StockAsset> { new StockAsset() { } },
                description = "",
                ID = 1,
                likers = new List<User> { },
                name = "name",
                publisher = new Publisher(),
                rating = new Rating(),
                tags = new string[] { "Deneme" },
                types = new string[] { "T" }
            });
            return new ContentResult()
            {
                ContentType = "text/html",
                Content = ""
            };
        }
    }
}
