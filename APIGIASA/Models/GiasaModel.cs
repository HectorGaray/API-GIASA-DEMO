using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace APIGIASA.Models
{
    public class GiasaModel { }

    [Table("tbaVendedor")]// Catalogo
    public class tbaVendedor
    {
        [Key]
        [Required]
        public Int32 idVendedor{ get; set; }
        public String nombre { get; set; }
        public String apellidos { get; set; }
        public String usuario { get; set; }
        public String pass { get; set; }
        public String fechaAlta { get; set; }
        public String ultimaEntrada { get; set; }


    }
    [Table("tbaProspectos")]
    public class tbaProspectos
    {
        [Key]
        [Required]
        public Int32 idProspecto { get; set; }
        public String nombrepros { get; set; }
        public String ap_materno { get; set; }
        public String ap_paterno { get; set; }
        public String direccion { get; set; }
        public String correo { get; set; }
        public String empresa { get; set; }
    }
    [Table("tbaInsumo")]
    public class tbaInsumo
    {
        [Key]
        [Required]
        public Int32 idInsumo { get; set; }
        public Int16 noPlaca { get; set; }
        public Decimal subTotal { get; set; }
        [ForeignKey("tbaMaquinaria")]
        public Int16 Maquinaria_idMaquina { get; set; }
        [ForeignKey("Cat_tinta")]
        public Int16 Cat_tinta_idTinta { get; set; }


        //FK Maquinaria, tinta
       public List<Cat_tinta> Cat_tinta { get; set; }
       public List<maquilastba> maquilastbas { get; set; }
        //  public List<Color>Color { get; set; }

    }
    [Table("tbaPlaca")]
    public class tbaPlaca
    {
        [Key]
        [Required]
        public Int32 idPlaca { get; set; }
        public String desPlaca { get; set; }
        public String medida { get; set; }
        public Decimal costoPlaca { get; set; }
       


    }
    [Table("CatInsumo")]
    public class CatInsumo
    {
        [Key]
        [Required]
        public Int32 idCatinsumo { get; set; }
        public String insumo { get; set; }
        public Decimal costohr { get; set; }



    }
    [Table("Cat_tinta")]
    public class Cat_tinta
    {
        [Key]
        [Required]
        public Int32 idTinta { get; set; }
        public String nombretin { get; set; }
        public Decimal precio { get; set; }
                
    }
    [Table("Color")]
    public class Color
    {
        [Key]
        [Required]
       
        public Int32 idColores { get; set; }
        //[ForeignKey("Cat_tinta")]
        public Int16 Cat_tinta_idTinta{ get; set; }
        //[ForeignKey("tbaInsumo")]
        public Int16 Insumo_idInsumo { get; set; }

        // FK de Cat_tinta, Insumos
         
       // public List<Cat_tinta> Cat_tintas { get; set; }
       // public List<tbaInsumo> tbaInsumos { get; set; }


    }
    [Table("tbaMaterial")]
    public class tbaMaterial
    {
        [Key]
        [Required]
        public Int32 idPapel { get; set; }
        public Decimal subtotal { get; set; }
        
     }
    [Table("papel")]
    public class papel
    {
        [Key]
        [Required]
        public Int32 idPapel { get; set; }
        public String nombre { get; set; }
        public Decimal precio { get; set; }
        
    }
    [Table("papelMat")]
    public class papelMat
    {
        [Key]
        [Required]
        public Int32 idPapelMat { get; set; }
        public Int16 cantidad { get; set; }
        public Int16 importe { get; set; }//revisar
        //[ForeignKey("papel")]
        public Int16 papel_idPapel { get; set; }
        //[ForeignKey("tbaMaterial")]
        public Int16 tbaMaterial_idMaterial{ get; set; }

        //FK de papel, tbaMaterial
        public List<papel> papel { get; set; }
        public List<tbaMaterial> tbaMaterial { get; set; }
    }
    [Table("tbaIndirecto")]
    public class tbaIndirecto
    {
        [Key]
        [Required]
        public Int32 idIndirecto { get; set; }
        public Decimal horas { get; set; }
        public Int16 minutos { get; set; }//revisar
        public Decimal importe { get; set; }
        public Decimal subtotalP { get; set; }
        public Decimal insumoV { get; set; }
        public Decimal materialV { get; set; }//revisar
        public Decimal subtotalV { get; set; }

      
    }
    [Table("maquilastba")]
    public class maquilastba      {
        [Key]
        [Required]
        public Int32 idMaquilaTba { get; set; }
        //[ForeignKey("maquilatba")]
        public Int16 maquilas_idMaquila { get; set; }
        //[ForeignKey("tbaMaquila")]
        public Int16 tbaMaquila_idMaquila { get; set; }//revisar

        //fk maquilas tbaMaquilas
        
      public List<tbaMaterial> tbaMaterial { get; set; }

    }

    [Table("tbaCotizacion")]
    public class tbaCotizacion
    {
        [Key]
        [Required]
        public Int32 idCotizacion { get; set; }
        public String folio { get; set; }
        public DateTime fecha { get; set; }//revisar
        public Decimal total { get; set; }
        public Decimal margenp { get; set; }
        public Decimal iva { get; set; }
        public Decimal grantotal { get; set; }//revisar
        public Decimal viatico { get; set; }
        //Fk
        //[ForeignKey("tbaVendedor")]
        public Int32 tbaVendedor_idVendedor  { get; set; }
        //[ForeignKey("tbaProspectos")]
        public Int16 tbaProspectos_idProspecto { get; set; }
        //[ForeignKey("tbaIndirecto")]
        public Int16 tbaIndirecto_idIndirecto { get; set; }//revisar
        //[ForeignKey("tbaMaquila")]
        public Int16 tbaMaquila_idMaquila  { get; set; }
        //[ForeignKey("mano_obra")]
        public Int16 mano_obra_idmano { get; set; }
        //[ForeignKey("tbaInsumo")]
        public Int16 tbaInsumo_idInsumo { get; set; }
        //[ForeignKey("tbaMaterial")]
        public Int16 tbaMaterial_idMaterial { get; set; }

        public Decimal cantidadP { get; set; }

        //fK de vendor, tba todos.
        public List<tbaVendedor> tbaVendedor { get; set; }

    }
    [Table("mano_obra")]
    public class mano_obra
    {
        [Key]
        [Required]
        public Int32 idmano { get; set; }
        public Int16 minDiseno { get; set; }
        public Int16 minPrensa { get; set; }//revisar
        public Int16 minFoliador { get; set; }
        public Decimal costoDiseño { get; set; }
        public Decimal costoPren { get; set; }
        public Decimal costoFolio { get; set; }//revisar
        public Decimal costoTerminado { get; set; }
        public Decimal subtotal { get; set; }

        
        


    }


}
