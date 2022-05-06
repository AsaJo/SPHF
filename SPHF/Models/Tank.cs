using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SPHF.Models
{
    public class Tank
    {
        public Tank()
        { }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string TankInfo { get; set; }
        //public Tank (string name )
        //{
        //    Name = name;
        //}
        [ForeignKey(nameof(Country))]
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public TankType TankType { get; set; }// Fördefinerade namn

    }// end of tankclass

    public enum TankType
    {
        HeavyTank, 
        MediumTank, 
        LightTank, 
        TankDestroyer, 
        SelfPropeldGun
    }//end of EnumTanktype
}// End of namespace