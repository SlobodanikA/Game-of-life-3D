
public static class GameData
{
    public static int MaxRows = 100;
    public static int MinRows = 10;
    public static int DefaultRows = 15;
    public static int CurrentRows = 15;
    public static void SetRows(int i) { CurrentRows = i;  updateMaxValues(); }

    public static int MaxCols = 100;
    public static int MinCols = 10;
    public static int DefaultCols = 15;
    public static int CurrentCols = 15;
    public static void SetCols(int i) { CurrentCols = i; updateMaxValues(); }

    public static int MaxIterations = 10000;
    public static int MinIterations = 10;
    public static int DefaultIterations = 100;
    public static int CurrentIterations = 100;
    public static void SetIterations(int i) { CurrentIterations = i; updateMaxValues(); }

    public static int MaxNumObstacles = CurrentCols * CurrentRows / 2;
    public static int RealMaxNumObstacles = (CurrentPrey + CurrentPredator) > MaxNumObstacles ? MaxNumObstacles : MaxNumObstacles * 2 - (CurrentPrey + CurrentPredator);
    public static int MinNumObstacles = 0;
    public static int DefaultObstacles = 0;
    public static int CurrentObstacles = 0;
    public static void SetObstacles(int i) { CurrentObstacles = i; updateMaxValues(); }

    public static int MaxNumPrey = CurrentCols * CurrentRows/2;
    public static int MinNumPrey = 6;
    public static int DefaultPrey = 50;
    public static int CurrentPrey = 50;
    public static void SetPrey(int i) { CurrentPrey = i; updateMaxValues(); }

    public static int MaxNumPredator = CurrentCols * CurrentRows/2;
    public static int RealMaxNumPredator = CurrentCols * CurrentRows - CurrentObstacles - CurrentPrey;
    public static int MinNumPredator = 2;
    public static int DefaultPredator = 10;
    public static int CurrentPredator = 10;
    public static void SetPredator(int i) { CurrentPredator = i; updateMaxValues(); }

    public  static string DefaultImage = "~";
    public  static string DefaultPreyImage = "F";
    public  static string DefaultPredatorImage = "S";
    public  static string ObstacleImage = "0";
    public  static string BorderImage = "*";

    public  static int TimeToFeed = 6;
    public  static int TimeToReproduce = 6;
    public  static int NumOfNeighbors = 4;

    public  static int NumBetweenIterations = 2000; //1000 = 1 second

    public static void updateMaxValues()
    {
        MaxNumPredator = CurrentCols * CurrentRows / 2 - CurrentObstacles - CurrentPrey;
        MaxNumObstacles = CurrentCols * CurrentRows / 2 - CurrentPrey - CurrentPredator;
        MaxNumPrey = CurrentCols * CurrentRows / 2 - CurrentObstacles - CurrentPredator;
    }
    public static void toDefault() 
    {
        CurrentCols = DefaultCols;
        CurrentObstacles = DefaultObstacles;
        CurrentPrey = DefaultPrey;
        CurrentPredator = DefaultPredator;
        CurrentRows = DefaultRows;
        updateMaxValues();
    }
    public static void save()
    {

    }
}