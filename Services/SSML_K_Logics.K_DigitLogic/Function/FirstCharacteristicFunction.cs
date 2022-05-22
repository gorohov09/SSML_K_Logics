namespace SSML_K_Logics.K_DigitLogic.Function
{
    public class FirstCharacteristicFunction
    {
        private readonly int _i;

        public FirstCharacteristicFunction(int i) { this._i = i; }

        public int Calculate(int x) => x == _i ? 1 : 0;    
    }
}
