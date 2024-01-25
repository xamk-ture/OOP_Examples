using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioExample
{

    public interface IMoveAble
    {
        void Move(int x, int y);
    }

    public class Test
    {
        public void TestFunction()
        {
            GameObject gameObject = new GameObject(100, 100, 50);

            Mario marioObject = new Mario(100, 200, 3);
            marioObject.Position = 1;
           

            Cloud cloudObject = new Cloud(100, 200, 2);
            cloudObject.Position = 2;

            var fireBall = new Fireball(10,10,7);
            Fireball ball = new(10, 10, 7);

            List<GameObject> gameObjects = new List<GameObject>();
            gameObjects.Add(ball);
            gameObjects.Add(marioObject);
            gameObjects.Add(cloudObject);

            foreach (var gObject in gameObjects)
            {
                if(gObject is IMoveAble)
                {
                    var moveable = (IMoveAble)gObject;
                    moveable.Move(100, 200);
                }
            }

            marioObject.SetHeight(10);
            int getHeight = marioObject.GetHeight();

            marioObject.PixeLHeight = 10;
            int propertyHeight = marioObject.PixeLHeight;


        }
    }

   

    public class GameObject
    {
        private int height;
       

        public int GetHeight()
        {
            return height;
        }

        public void SetHeight(int height)
        {
            this.height = height;

            Console.WriteLine($"The height was incresed by {height}");
        }


        public int TestProperty
        {
            get
            {
                return this.height;
            }

            set
            {
               height = value;    
            }
        }

        public int PixeLHeight { get; set; }

        public int PixeLWidth { get; set; }

        public int Position { get; set; }
        public string Color { get; set; }

        private int ZIndex { get; set; }

        public GameObject(int height, int width, int position)
        {
            PixeLHeight = height; 
            PixeLWidth = width;
            Position = position;
        }
    }

    public class Fireball : GameObject, IMoveAble
    {
        public Fireball(int height, int width, int position) : base(height, width, position)
        {
        }

        public void Move(int x, int y)
        {
            //Diffrent kind of logic
            //This fireball will move to one direction only where it was fired
        }
    }

    public class Mario : GameObject, IMoveAble
    {
        public int Lives { get; set; }

        public Mario(int height, int width, int position) : base(height, width, position)
        { 
        }

        public void Move(int x, int y)
        {
            //Here we would have a move logic
            //Move the direction that player is pressing
        }
    }

    public class Cloud : GameObject
    {

        public Cloud(int height, int width, int position) : base(height, width, position)
        {
        }
    }

    public class Block : GameObject
    {
     
        public int Coins { get; set; }  

        public string PowerUp { get; set; }

        public Block(int height, int width, int position) : base(height, width, position)
        {
        }
    }
}
