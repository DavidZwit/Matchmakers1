public class ArrayEditor
{
    public static ArrayDataType[,] ToToDem<ArrayDataType> (ArrayDataType[] array)
    {
        int nextRow = -1;
        int arrayCounter = 0;
        int skipPos = (int)System.Math.Sqrt(array.Length);
        ArrayDataType[,] sortedArray = new ArrayDataType[skipPos, skipPos];

        for (int i = 0; i < array.Length; i++) {
            if (i % skipPos == 0) {
                nextRow++;
                arrayCounter = 0;
            }
            sortedArray[nextRow, arrayCounter] = array[i];
            arrayCounter++;
        }
        return sortedArray;
    }

    public static ArrayDataType[] ToOneDem<ArrayDataType> (ArrayDataType[,] TwoDemArray)
    {
        int arrayCounter = 0;
        int planeSize = TwoDemArray.GetLength(0);
        ArrayDataType[] returnArray = new ArrayDataType[planeSize * planeSize];

        for (int x = 0; x < planeSize; x++) {
            for (int y = 0; y < planeSize; y++) {
                returnArray[arrayCounter] = TwoDemArray[x, y];
                arrayCounter++;
            }
        }

        return returnArray;
    }
}
