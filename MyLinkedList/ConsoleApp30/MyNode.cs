namespace ConsoleApp30
{
    class MyNode<T>
    {
        public T Value { get; set; }
        public MyNode<T> Next { get; set; } 

        public override string ToString()
        {
            return Value.ToString();
        }

		public override bool Equals(object obj)
		{
			return this.Value.Equals((obj as MyNode<T>).Value);
		}
	}
}
