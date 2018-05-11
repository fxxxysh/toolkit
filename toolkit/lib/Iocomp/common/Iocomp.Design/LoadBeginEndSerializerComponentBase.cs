using Iocomp.Classes;
using System.CodeDom;
using System.ComponentModel.Design.Serialization;

namespace Iocomp.Design
{
	public class LoadBeginEndSerializerComponentBase : CodeDomSerializer
	{
		public override object Deserialize(IDesignerSerializationManager manager, object codeDomObject)
		{
			CodeDomSerializer codeDomSerializer = (CodeDomSerializer)manager.GetSerializer(typeof(ComponentBase).BaseType, typeof(CodeDomSerializer));
			return codeDomSerializer.Deserialize(manager, codeDomObject);
		}

		public override object Serialize(IDesignerSerializationManager manager, object value)
		{
			CodeDomSerializer codeDomSerializer = (CodeDomSerializer)manager.GetSerializer(typeof(ComponentBase).BaseType, typeof(CodeDomSerializer));
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
			int num = 0;
			for (int i = 0; i < codeStatementCollection.Count; i++)
			{
				if (codeStatementCollection[i] is CodeCommentStatement)
				{
					num = i + 1;
				}
			}
			codeStatementCollection.Insert(num, new CodeExpressionStatement(expression));
			expression = new CodeMethodInvokeExpression(codeExpression, "SetForm", new CodeThisReferenceExpression());
			codeStatementCollection.Insert(num + 1, new CodeExpressionStatement(expression));
			expression = new CodeMethodInvokeExpression(codeExpression, "LoadingEnd");
			codeStatementCollection.Add(expression);
			return obj;
		}
	}
}
