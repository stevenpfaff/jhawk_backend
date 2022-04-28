using Microsoft.AspNetCore.Http;
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
    public class GameController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public GameController(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                select * from dbo.Games";
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
        [HttpPost]
        public JsonResult Post(Game gm)
        {
            string query = @"
                    insert into dbo.Games
                    (HomeTeam,AwayTeam,HomeScore,AwayScore) 
                    values
                    (
                    '" + gm.HomeTeam + @"'
                    ,'" + gm.AwayTeam + @"'
                    ,'" + gm.HomeScore + @"'
                    ,'" + gm.AwayScore + @"'
                    )
                    ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("PlayerAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Game Added Successfully");
        }
        [HttpPut]
        public JsonResult Put(Game gm)
        {
            string query = @"
                    update dbo.Games set                    
                    HomeTeam='" + gm.HomeTeam + @"'
                    ,AwayTeam='" + gm.AwayTeam + @"'
                    ,HomeScore='" + gm.HomeScore + @"'
                    ,AwayScore='" + gm.AwayScore + @"'
                    where Id = " + gm.Id + @"
                    ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("PlayerAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Game Updated Successfully");
        }
    }
}
