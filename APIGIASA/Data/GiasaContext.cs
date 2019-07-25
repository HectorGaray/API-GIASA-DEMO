using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using APIGIASA.Models;
namespace APIGIASA.Data
{
    public class GiasaContext: DbContext
    {
        public GiasaContext(DbContextOptions<GiasaContext> options)
            : base(options)
        {

        }
        public DbSet<tbaVendedor> tbaVendedor { get; set; }

        public DbSet<tbaProspectos> tbaProspecto { get; set; }

        public DbSet<tbaInsumo> tbaInsumo { get; set; }

        public DbSet<tbaPlaca> tbaPlaca { get; set; }

        public DbSet<CatInsumo> CatInsumo { get; set; }

        public DbSet<Cat_tinta> Cat_tinta { get; set; }

        public DbSet<Color> Color { get; set; }

        public DbSet<tbaMaterial> tbaMaterial { get; set; }

        public DbSet<papelMat> papelMat { get; set; }


        public DbSet<tbaIndirecto> tbaIndirecto { get; set; }

        public DbSet<maquilastba> maquilastbas { get; set; }

        public DbSet<tbaCotizacion> tbaCotizacion { get; set; }

        public DbSet<mano_obra> mano_obra { get; set; }

        





    }
}