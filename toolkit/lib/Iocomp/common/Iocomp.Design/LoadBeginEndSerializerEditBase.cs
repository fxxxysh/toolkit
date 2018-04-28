using Iocomp.Classes;
using System.CodeDom;
using System.ComponentModel.Design.Serialization;

namespace Iocomp.Design
{
	public class LoadBeginEndSerializerEditBase : CodeDomSerializer
	{
		public override object Deserialize(IDesignerSerializationManager manager, object codeDomObject)
		{
			CodeDomSerializer codeDomSerializer = (CodeDomSerializer)manager.GetSerializer(typeof(EditBase).BaseType, typeof(CodeDomSerializer));
			return codeDomSerializer.Deserialize(manager, codeDomObject);
		}

		public override object Serialize(IDesignerSerializationManager manager, object value)
		{
			CodeDomSerializer codeDomSerializer = (CodeDomSerializer)manager.GetSerializer(typeof(EditBase).BaseType, typeof(CodeDomSerializer));
			object obj = codeDomSerializer.Serialize(manager, value);
			CodeExpression codeExpression = base.SerializeToExpression(manager, value);
			if (codeExpression == null)
			{
				return obj;
			}
			if (!(obj is CodeStatementCollection))
			{
				return obj;
			}
			CodeStatementCollection codeStatementCollection = (CodeStatementCollection)obj;
			CodeMethodInvokeExpression expression = new CodeMethodInvokeExpression(codeExpression, "LoadingBegin");
			int index = 0;
			for (int i = 0; i < codeStatementCollection.Count; i++)
			{
				if (codeStatementCollection[i] is CodeCommentStatement)
				{
					index = i + 1;
				}
			}
			codeStatementCollection.Insert(index, new CodeExpressionStatement(expression));
			expression = new CodeMethodInvokeExpression(codeExpression, "LoadingEnd");
			codeStatementCollection.Add(expression);
			return obj;
		}
	}
}
