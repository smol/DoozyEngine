using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace DoozyEngine
{
    public class Camera
    {
        // rectangle representant la zone affichée
        static public Rectangle ViewingRectangle 
        { 
            get 
            {
                return new Rectangle ((int)(-Camera.Position.X), (int)(-Camera.Position.Y),
                                RootEngine.GraphicController.Width, RootEngine.GraphicController.Height);
            } 
        }

        // position Max de la camera
        static public Vector2 Max;

        // position de la camera
        static private Vector2 position;
        static public Vector2 Position 
        { 
            get { return Camera.position; }
            set { Camera.position = value; }
        }

        // deplacement de la camera
        static public void Move(Vector2 heroePosition)
        {
            Vector2 temp = -(heroePosition * GraphicController.TILE_SIZE);
            //temp.Y -= GraphicController.TILE_SIZE;
            //temp.X -= GraphicController.TILE_SIZE;
            temp *= RootEngine.GraphicController.Scale;
            temp.X += Camera.ViewingRectangle.Width / 2;
            temp.Y += Camera.ViewingRectangle.Height / 2;

            if (temp == Camera.position)
                return;

            if (temp.X > 0) temp.X = 0;
            else if (temp.X < Camera.Max.X) temp.X = Camera.Max.X;// -(GraphicController.TILE_SIZE / 2);

            if (temp.Y > 0) temp.Y = 0;
            else if (temp.Y < Camera.Max.Y) temp.Y = Camera.Max.Y;// -(GraphicController.TILE_SIZE / 2);

            Camera.position = temp;
        }

        static public void Move(Vector2 amount, Vector2 entityPosition)
        {
            if (amount == Vector2.Zero)
                return;

            amount *= RootEngine.GraphicController.Scale;

            Vector2 temp = Camera.position + amount;
            
            bool[] ret = Camera.IsCentred(amount, entityPosition);

            if (temp.X <= 0 && temp.X >= Camera.Max.X && ret[0])
                Camera.position.X = temp.X;

            if (temp.Y <= 0 && temp.Y >= Camera.Max.Y && ret[1])
                Camera.position.Y = temp.Y;
        }

        static public bool[] IsCentred(Vector2 amount, Vector2 entityPosition)
        {
            bool[] ret = new bool[2] {false, false};

            //Vector2 centerPosition = new Vector2(center.X, center.Y) * GameRoot.ScaleWindow;
            //centerPosition.X -= position.X + amount.X;
            //centerPosition.Y -= position.Y + amount.Y;
            
            //if (entityPosition.X < Camera.ViewingRectangle.X + (Camera.ViewingRectangle.Width / 2)

            //if (entityPosition.X + amount.X >= Camera.ViewingRectangle.X + (Camera.ViewingRectangle.Width / 2) || 
            //    ret[0] = true;

            //if (entityPosition.Y >= centerPosition.Y && entityPosition.Y <= (centerPosition.Y + center.Height))
            //    ret[1] = true;

            return ret;
        }

        static public Matrix GetTransform()
        {
            return Matrix.CreateRotationZ(0.0f) * Matrix.CreateScale(RootEngine.GraphicController.Scale.X) *
                   Matrix.CreateTranslation(position.X, position.Y, 0);
        }
    }
}
