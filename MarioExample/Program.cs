namespace MarioExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Mario mario = new Mario(100, 50, 2, 1);

            Block block = new Block(100, 50, 2, 1);

            GameObject gameObject = new GameObject(100, 100, 1, 2);
            gameObject.PositionX = 10;   
        }
    }

    public class GameEngine
    {
        public List<GameObject> GameObjects = new List<GameObject> ();


        public GameEngine(List<GameObject> gameObjects)
        {
            GameObjects = gameObjects;

            var testObject = new GameObject(100, 50, 2, 1);

            DrawObject(gameObjects);

            DrawObject(testObject);

        }

        //This fucntion is automatically called 60 times per second
        public void Update()
        {
            foreach (var gameObject in GameObjects)
            {
                if (gameObject is IMoveable)
                {
                    IMoveable moveable = (IMoveable)gameObject;
                }
            }
        }

        private void DrawObject(GameObject gameObject)
        {
            //Draw object to the screen logic
        }

        private void DrawObject(List<GameObject> gameObjects)
        {
            foreach (var gameObject in gameObjects)
            {
                DrawObject(gameObject);
            }
        }
    }

    public class GameObject
    {
        public int PixelHeight { get; set; }

        public int PixelWidth { get; set; }

        public string Color { get; set; }

        public int PositionX { get; set; }

        public int PositionY { get; set; }


        public int ZIndex { get; set; }

        /// <summary>
        /// Game object constructor
        /// </summary>
        /// <param name="pixelHeight">Game object pixel height</param>
        /// <param name="pixelWidth"></param>
        /// <param name="positionX"></param>
        /// <param name="positionY"></param>
        public GameObject(int pixelHeight, int pixelWidth, int PositionX, int positionY)
        {
            //if the property is same name as the parameter we need to use this keyword
            //so the computer knows what to use
            this.PositionX = PositionX;

            PositionY = positionY;

            PixelHeight = pixelHeight;

            PixelWidth = pixelWidth;
        }
    }

    public interface IMoveable
    {
        void Move(int x, int y);

    }

    public class FireBall : GameObject, IMoveable
    {
        public FireBall(int pixelHeight, int pixelWidth, int PositionX, int positionY)
          : base(pixelHeight, pixelWidth, PositionX, positionY)
        {

        }

        public void Move(int x, int y)
        {
            //Fireball move logic here
        }
    }


    public class Mario : GameObject, IMoveable
    {
        private int _lives;

        public void SetLives(int lives)
        {
            _lives = lives;

            if(lives == 0)
            {
                Console.WriteLine("Mario is dead");
            }
        }

        public int GetLives()
        {
            return _lives;  
        }

        public int AnotherLive
        {
            get
            {
                return _lives;
            }
            set
            {
                _lives = value;

                if (_lives == 0)
                {
                    Console.WriteLine("Mario is dead");
                }

            }
        }

        public int Lives { get; set; }

        public Mario(int pixelHeight, int pixelWidth, int PositionX, int positionY)
            : base(pixelHeight, pixelWidth, PositionX, positionY)
        {

        }

        public void Move(int x, int y)
        {
            //Mario move logic
        }
    }

    public class Block : GameObject
    {

        public int Coins { get; set; }

        public Block(int pixelHeight, int pixelWidth, int PositionX, int positionY)
           : base(pixelHeight, pixelWidth, PositionX, positionY)
        {

        }
    }

    public class Cloud : GameObject
    {
        public Cloud(int pixelHeight, int pixelWidth, int PositionX, int positionY)
         : base(pixelHeight, pixelWidth, PositionX, positionY)
        {
            Console.WriteLine("Leijailen");
        }
    }


}