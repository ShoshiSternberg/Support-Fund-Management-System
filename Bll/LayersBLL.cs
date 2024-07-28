using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto;
using Dal;
namespace Bll
{
    public class LayersBLL
    {
        //שליפת כל השכבות
        public static List<LayersDTO> GetAllLayers()
        {
            try
            {
                return LayersDTO.toDTO_List(LayersDAL.GetAllLayers());
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //שליפת שכבה לפי קוד
        public static LayersDTO GetLayerByID(int ID)
        {
            try
            {
                return LayersDTO.toLayersDTO(LayersDAL.GetLayerByID(ID));
            }
            catch(Exception e)
            {
                return null;
            }

        }

        //הוספת שכבה
        public static bool InsertLayer( string LName)
        {
            try
            {
                LayersDTO newld = new LayersDTO();
                
                newld.Layer = LName;

                return LayersDAL.InsertLayer(LayersDTO.toLayers(newld));
            }
            catch(Exception e)
            {
                return false;
            }
        }
    }
}
