using CineGlobe_API.Models;
using CineGlobeAPI.Access;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineGlobe_API.Logic
{
    public  class DataLogic
    {

        private readonly Database _database = new Database();
        private readonly IConfiguration _configuration;

        public List<AllFilmsModel> GetFilmData()
        {

            // ESTABLISH LIST MODEL
            var allFilmsList = new List<AllFilmsModel>();

            try
            {

                //SELECTING ALL AVAILABLE COLUMNS FROM SQLEXPRESSDB ON ME1150 (LOCAL MACHINE)
                var sql = $@"SELECT 
                                  RELEASE_DATE
                                  ,REPLACE(TITLE,';',',') AS 'TITLE'
                                  ,REPLACE(OVERVIEW,';',',') AS 'OVERVIEW'
                                  ,ROUND(POPULARITY,2) AS POPULARITY
                                  ,VOTE_COUNT
                                  ,ROUND(VOTE_AVERAGE,2) AS VOTE_AVERAGE
                                  ,ORIGINAL_LANGUAGE
                                  ,GENRE
                                  ,POSTER_URL
                            FROM 
                                  CINEDB.DBO.MYMOVIEDB";

                var dt = _database.RunSQLReturnTableData(sql);

                if(dt.Rows.Count > 0)
                {
                    //MAPPING DATAROWS INTO 'ALLFILMSMODEL' MODEL
                    allFilmsList = dt.Rows.Cast<DataRow>().Select(x => new AllFilmsModel(
                        Convert.ToDateTime(x["RELEASE_DATE"]),
                        x["TITLE"].ToString(),
                        x["OVERVIEW"].ToString(),
                        x["POPULARITY"].ToString(),
                        x["VOTE_COUNT"].ToString(),
                        x["VOTE_AVERAGE"].ToString(),
                        x["ORIGINAL_LANGUAGE"].ToString(),
                        x["GENRE"].ToString(),
                        x["POSTER_URL"].ToString()
                        )).ToList();               
                }  
            }
            catch (Exception ex)
            {
                //ERROR HANDLE FOR EXCEPTION, NO LOGGING CLASSES DEFINED SO ONLY OUTPUTTING TO DUMMY CONSOLE.
                Console.WriteLine(ex.ToString());
            }

            return allFilmsList;

        }

    }
}
