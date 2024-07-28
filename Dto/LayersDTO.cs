using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;

namespace Dto
{
    public class LayersDTO
    {
        private int layerID;

        public int LayerID
        {
            get { return layerID; }
            set { layerID = value; }
        }

        private string layer;

        public string Layer
        {
            get { return layer; }
            set { layer = value; }
        }


        //פונקציות המרה

        //המרת אוביקט שלנו לאוביקט של מיקרוסופט
        public static Layers toLayers(LayersDTO AS)
        {
            try
            {
                Layers newLD = new Layers();
                newLD.LayerID = AS.LayerID;
                newLD.Layer = AS.layer;
                return newLD;
            }
            catch
            {
                return null;
            }

        }

        // המרת אוביקט מיקרוסופט  לאוביקט שלנו 
        public static LayersDTO toLayersDTO(Layers AS)
        {
            try
            {
                LayersDTO newLD = new LayersDTO();
                newLD.LayerID = AS.LayerID;
                newLD.Layer = AS.Layer;
                return newLD;

            }
            catch
            {
                return null;
            }


        }


        //המרת אוסף ממיקרוסופט לשלנו
        public static List<LayersDTO> toDTO_List(List<Layers> AS)
        {
            List<LayersDTO> AList = new List<LayersDTO>();
            try
            {
                foreach (var item in AS)
                {
                    AList.Add(toLayersDTO(item));
                }
                return AList;
            }
            catch (Exception e)
            {
                return null;
            }


        }
        //המרת אוסף  שלנו לשל מיקרוסופט
        public static List<Layers> toTBL_List(List<LayersDTO> AS)
        {
            List<Layers> AList = new List<Layers>();
            try
            {
                foreach (var item in AS)
                {
                    AList.Add(toLayers(item));
                }
                return AList;
            }
            catch (Exception e)
            {
                return null;
            }

        }

    }
}
