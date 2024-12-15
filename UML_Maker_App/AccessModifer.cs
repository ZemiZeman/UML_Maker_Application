namespace UML_Maker_App
{
    public enum AccessModifer
    {
        Public,
        Private,
        Protected,
        Internal
    }

    public static class AccessModifierToSign
    {
        public static string ToSign(this AccessModifer accessModifer)
        {
            return accessModifer switch
            {
                AccessModifer.Public => "+",
                AccessModifer.Private => "-",
                AccessModifer.Protected => "#",
                AccessModifer.Internal => "~"
            };
        }

        public static string InCodeFormat(this AccessModifer accessModifer)
        {
            return accessModifer.ToString().ToLower();
        }
    }
}
