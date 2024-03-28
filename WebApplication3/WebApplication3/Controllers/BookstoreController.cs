using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookstoreController : ControllerBase
    {
        private readonly string connectionString;

        public BookstoreController(IConfiguration configuration)
        {
            connectionString = configuration["ConnectionStrings:BookstoreDB"] ?? "";
        }

        [HttpPost]
        public IActionResult AddBook(bookContent2Dto _bookContent2Dto)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "INSERT INTO bookContent3" + "(id,name,author,theme) VALUES" + "(@id,@name,@author,@theme)";

                    using(var command=new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", _bookContent2Dto.Id);
                        command.Parameters.AddWithValue("@name", _bookContent2Dto.Name);
                        command.Parameters.AddWithValue("@author", _bookContent2Dto.Author);
                        command.Parameters.AddWithValue("@theme", _bookContent2Dto.Theme);

                        command.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex )
            {

                ModelState.AddModelError("bookContent", ex.ToString());
                return BadRequest(ModelState);
            }
            return Ok();
        }
        [HttpGet("content")]
        public IActionResult GetBookContent()
        {
            List<bookContent>bookContents = new List<bookContent>();
            try 
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM bookContent3";
                    using (var command = new SqlCommand(sql, connection))
                    {
                        using(var reader=command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                bookContent _bookContent = new bookContent();

                                _bookContent.Id = reader.GetInt32(0);
                                _bookContent.Name = reader.GetString(1);
                                _bookContent.Author = reader.GetString(2);
                                _bookContent.Theme = reader.GetString(3);

                                bookContents.Add(_bookContent);
                            }
                        }
                    }
                }


            }
            catch(Exception ex)
            {
                ModelState.AddModelError("bookContent", ex.ToString());
                return BadRequest(ModelState);
            }

            return Ok(bookContents);

        }
        [HttpGet("feature")]
        public IActionResult GetBookFeature()
        {
            List<bookFeature> bookFeatures = new List<bookFeature>();
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM bookFeature";
                    using (var command = new SqlCommand(sql, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                bookFeature _bookFeature = new bookFeature();

                                _bookFeature.Id = reader.GetInt32(0);
                                _bookFeature.Name = reader.GetString(1);
                                _bookFeature.bookPage = reader.GetInt32(2);
                                _bookFeature.Publisher = reader.GetString(3);
                                _bookFeature.printingNo = reader.GetInt32(4);

                                bookFeatures.Add(_bookFeature);
                            }
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                ModelState.AddModelError("bookContent", ex.ToString());
                return BadRequest(ModelState);
            }

            return Ok(bookFeatures);

        }
        [HttpGet("price")]
        public IActionResult GetBookPrice()
        {
            List<bookPrice> bookPrices = new List<bookPrice>();
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM bookPrice";
                    using (var command = new SqlCommand(sql, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                bookPrice _bookPrice = new bookPrice();

                                _bookPrice.Id = reader.GetInt32(0);
                                _bookPrice.Name = reader.GetString(1);
                                _bookPrice.Stock = reader.GetInt32(2);
                                _bookPrice.Price = reader.GetInt32(3);

                                bookPrices.Add(_bookPrice);
                            }
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                ModelState.AddModelError("bookContent", ex.ToString());
                return BadRequest(ModelState);
            }

            return Ok(bookPrices);

        }
    }
}
