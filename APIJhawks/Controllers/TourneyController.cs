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

        public class TourneyController : ControllerBase
        {
            private readonly IConfiguration _configuration;

            public TourneyController(IConfiguration configuration)
            {
                _configuration = configuration;

            }

            [HttpGet]
            public JsonResult Get()
            {
                string query = @"
                select * from dbo.Tourney";
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
            public JsonResult Post(Tourney gm)
            {
                string query = @"
                    insert into dbo.Tourney
                    (HomeTeam,AwayTeam,HomeScore,AwayScore,Name) 
                    values
                    (
                    '" + gm.HomeTeam + @"'
                    ,'" + gm.AwayTeam + @"'
                    ,'" + gm.HomeScore + @"'
                    ,'" + gm.AwayScore + @"'
                    ,'" + gm.Name + @"'
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
            public JsonResult Put(Tourney gm)
            {
                string query = @"
                    update dbo.Games set                    
                    HomeTeam='" + gm.HomeTeam + @"'
                    ,AwayTeam='" + gm.AwayTeam + @"'
                    ,HomeScore='" + gm.HomeScore + @"'
                    ,AwayScore='" + gm.AwayScore + @"'
                    ,Name='" +gm.Name + @"'
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
