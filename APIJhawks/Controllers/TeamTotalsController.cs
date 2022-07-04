using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using APIJhawks.Models;

namespace APIJhawks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamTotalsController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        public TeamTotalsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                select * from dbo.Team";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("PlayerAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }
            return new JsonResult(table);
        }
    }
}

