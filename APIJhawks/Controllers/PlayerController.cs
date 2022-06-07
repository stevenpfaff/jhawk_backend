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
    public class PlayerController : ControllerBase
    {
        
        private readonly IConfiguration _configuration;
        public PlayerController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                select * from dbo.Player";
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
        [HttpGet("{id:int}")]
        public JsonResult Get(int Id)
        {
            string query = @"
                select * from dbo.Player";
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
        public JsonResult Post(Player ply)
        {
            string query = @"
                    insert into dbo.Player
                    (Name, GP, AB, H, R, RBI,DBL,TPL, HR, SLG, BB, K, IP, Walks, Strikeouts, BALL, STRK, PT, PO, A, E, FP, SB, CS,SBP, AVG, WHIP, FIP, OBP, OPS, ERA, CCS)
                    values 
                    (
                    '" + ply.Name + @"'
                    ,'" + ply.GP + @"'
                    ,'" + ply.AB + @"'
                    ,'" + ply.H + @"'
                    ,'" + ply.R + @"'
                    ,'" + ply.RBI + @"'
                    ,'" + ply.DBL + @"'
                    ,'" + ply.TPL + @"'
                    ,'" + ply.HR + @"'
                    ,'" + ply.SLG + @"'
                    ,'" + ply.BB + @"'
                    ,'" + ply.K + @"'
                    ,'" + ply.IP + @"'
                    ,'" + ply.Walks + @"'
                    ,'" + ply.Strikeouts + @"'
                    ,'" + ply.BALL + @"'
                    ,'" + ply.STRK + @"'
                    ,'" + ply.PT + @"'
                    ,'" + ply.PO + @"'
                    ,'" + ply.A + @"'
                    ,'" + ply.E + @"'
                    ,'" + ply.FP + @"'
                    ,'" + ply.SB + @"'
                    ,'" + ply.CS + @"'
                    ,'" + ply.SBP + @"'
                    ,'" + ply.AVG + @"'
                    ,'" + ply.WHIP + @"'
                    ,'" + ply.OPS + @"'
                    ,'" + ply.OBP + @"'
                    ,'" + ply.FIP + @"'
                    ,'" + ply.ERA + @"'
                    ,'" + ply.CCS + @"'
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

            return new JsonResult("Player Added Successfully");
        }
        [HttpPut]
        public JsonResult Put(Player ply)
        {
            string query = @"
                    update dbo.Player set 
                    Name = '" + ply.Name + @"'
                    ,GP = '" + ply.GP + @"'
                    ,AB = '" + ply.AB + @"'
                    ,H = '" + ply.H + @"'
                    ,R ='" + ply.R + @"'
                    ,RBI ='" + ply.RBI + @"'
                    ,DBL ='" + ply.DBL + @"'
                    ,TPL = '" + ply.TPL + @"'
                    ,HR = '" + ply.HR + @"'
                    ,SLG ='" + ply.SLG + @"'
                    ,BB ='" + ply.BB + @"'
                    ,K = '" + ply.K + @"'
                    ,IP ='" + ply.IP + @"'
                    ,Walks = '" + ply.Walks + @"'
                    ,Strikeouts ='" + ply.Strikeouts + @"'
                    ,BALL ='" + ply.BALL + @"'
                    ,STRK ='" + ply.STRK + @"'
                    ,PT ='" + ply.PT + @"'
                    ,PO ='" + ply.PO + @"'
                    ,A = '" + ply.A + @"'
                    ,E ='" + ply.E + @"'
                    ,FP='" + ply.FP + @"'
                    ,SB='" + ply.SB + @"'
                    ,CS='" + ply.CS + @"'
                    ,SBP='" + ply.SBP + @"'
                    ,AVG='" + ply.AVG + @"'
                    ,WHIP='" + ply.WHIP + @"'
                    ,OPS='" + ply.OPS + @"'
                    ,OBP='" + ply.OBP + @"'
                    ,FIP='" + ply.FIP + @"'
                    ,ERA='" + ply.ERA + @"'
                    ,ERA='" + ply.CCS + @"'
                    where Id = " + ply.Id+@"
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

            return new JsonResult("Player Updated Successfully");
        }
    }
}
