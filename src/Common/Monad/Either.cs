namespace Common.Monad
{
    public class Either<TLeft, TRight>
    {
        private readonly TLeft _left;
        private readonly TRight _right;

        public Either(TLeft left)
        {
            _left = left;
        }

        public Either(TRight right)
        {
            _right = right;
        }

        public TOut ReduceTo<TOut>(Func<TLeft, TOut> leftMapping, Func<TRight, TOut> rightMapping)
        {
            return _left != null ? leftMapping(_left) : rightMapping(_right);
        }

        public static implicit operator Either<TLeft, TRight>(TLeft left)
        {
            return new Either<TLeft, TRight>(left);
        }

        public static implicit operator Either<TLeft, TRight>(TRight right)
        {
            return new Either<TLeft, TRight>(right);
        }
    }
}
