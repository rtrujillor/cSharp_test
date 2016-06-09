using System;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;

namespace RefactoringGeometricalShapes
{

    // Interface of all Shapes
    public interface IShape 
    {
        double getWidth();
        double getArea();
        double getPerimeter();
        
    }
    
    // Abstract class for Shape
    public abstract class Shape : IShape 
    {
   
        public ResourceManager resourceManager;    
        public CultureInfo cultureInfo;            
        
        protected double width;
        
        public abstract double getWidth();
        public abstract double getArea();
        public abstract double getPerimeter();
        
        // Method to init the language of the shapes - see Resource folder for keys)
        public void initLanguage(int language)
        {
             if (language == 1)    
             { 
               cultureInfo = CultureInfo.CreateSpecificCulture("en");    
             }          
             else                                                
             {
              cultureInfo = CultureInfo.CreateSpecificCulture("de");     
             }   
        }
        
        // Common method to get width of shapes
        public double getWidth()
        {
            return width;   
        }  
        
        // Common Pretty Pink with multilanguage
        public static String prettyPrint(List<Shape> shapes , int userLanguage)
        {
            if (shapes.Count == 0)
            {
                returnString = resourceManager.GetString("empty_list_key");

            } 
            else
            {
                //we have shapes
                //header // better using a string builder !!
                returnString += "<h1>" + resourceManager.GetString("header_key"); + "</h1><br/>";
            }
            
             //compute numbers
            for (int i = 0; i < shapes.Count; i++)
            {
              if (shapes[i].getType() ==  "Square")
              {
                numberSquares++;
                areaSquares += shapes[i].getArea();
                perimeterSquares += shapes[i].getPerimeter();
              }
              if (shapes[i].getType() == "Circle")
              {
                numberCircles++;
                areaCircles += shapes[i].getArea();
                perimeterCircles += shapes[i].getPerimeter();
              }
            }
            ....
            ....
            
            return returnString;
        }
        
        
        
        
    }
    
    // Class for Square 
    public class Square : Shape 
    {
        
        public Square(double width)
        {
          this.width = width;
        } 

    
        public double getArea()
        {
            return width * width;
        }
        
        public double getPerimeter()
        {
            return 4 * width;
        }
    }
    
    // Class for Circle
    public class Circle : Shape 
    {
        .....   
    }
}