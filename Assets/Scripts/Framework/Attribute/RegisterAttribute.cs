using System;


//特性模板
public class RegisterAttribute:Attribute
{
    //生成的Helper的名字
    public string registerTypeName;

    public RegisterAttribute(string registerTypeName)
    {
        this.registerTypeName = registerTypeName;
    }

}
