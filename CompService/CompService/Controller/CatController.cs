using CompService.Data;
using CompService.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompService.Controller
{
    public class CatController : EntityController
    {
        public CatController() : base(App.SqlConnection)
        {
            App.SqlConnection.CreateTableAsync<Cat>();
        }
    }
}
