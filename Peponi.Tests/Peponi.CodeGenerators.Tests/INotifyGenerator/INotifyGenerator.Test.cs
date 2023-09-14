using System.Diagnostics;

namespace Peponi.CodeGenerators.Tests.INotifyGenerator;

[TestClass]
public class INotify
{
    [TestMethod]
    public void Compare()
    {
        Assert.IsTrue(INotifyCompare.CompareCode(
@"using Peponi.CodeGenerators;

namespace CodeGeneratorTest;

[INotify]
public static sealed partial class CodeTest
{
}",
@"// Auto generated code by Peponi.CodeGenerators
// Github : https://github.com/peponi-paradise/Peponi
// Blog : https://peponi-paradise.tistory.com

#nullable enable

using System.ComponentModel;

namespace CodeGeneratorTest
{
    public static sealed partial class CodeTest : INotifyPropertyChanged
    {
        /// <inheritdoc cref=""INotifyPropertyChanged.PropertyChanged""/>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Raises the <see cref=""PropertyChanged""/> event
        /// </summary>
        /// <param name=""e"">A <see cref=""PropertyChangedEventArgs""/> that contains the name of the changed property.</param>
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref=""PropertyChanged""/> event.
        /// </summary>
        /// <param name=""propertyName"">(optional) The name of the property that changed.</param>
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
    }
}"));
    }
}