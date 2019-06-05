using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO
{
    //Для хранения редко изменяемой информации о учреждении, заказчиках и т.д.(Например Руководитель учреждения, ИНН, КПП, Главный бухгалтер)
    public class InfoStatic
    {
        [Key]
        public string Name { get; set; }    //Наименование данных (Главный бухгатер)
        public string Info { get; set; }    //Данные (Иванова И.И.)
    }
}
