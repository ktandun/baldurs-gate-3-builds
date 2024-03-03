using BG3Builds.Database;
using BG3Builds.Scraper.Generators;
using BG3Builds.Scraper.Scrapers;

const string connectionString = "Host=localhost;Database=bg3builds;Username=postgres;Password=password";

await using var database = new DatabaseContext(connectionString);

database.Database.EnsureDeleted();
database.Database.EnsureCreated();

AmuletScraper.Scrape(connectionString, "./HtmlResources/amulets.html");
ArmourScraper.Scrape(connectionString, "./HtmlResources/armours.html");
CloakScraper.Scrape(connectionString, "./HtmlResources/cloaks.html");
ClothingScraper.Scrape(connectionString, "./HtmlResources/clothings.html");
FootwearScraper.Scrape(connectionString, "./HtmlResources/footwears.html");
HandwearScraper.Scrape(connectionString, "./HtmlResources/handwears.html");
HeadwearScraper.Scrape(connectionString, "./HtmlResources/headwears.html");
RingScraper.Scrape(connectionString, "./HtmlResources/rings.html");
WeaponScraper.Scrape(connectionString, "./HtmlResources/weapons.html");

await ObjectImageScraper.ScrapeAsync(connectionString);

FeatScraper.Scrape(connectionString, "./HtmlResources/feats.html");

JsonGenerator.GenerateJson(connectionString);