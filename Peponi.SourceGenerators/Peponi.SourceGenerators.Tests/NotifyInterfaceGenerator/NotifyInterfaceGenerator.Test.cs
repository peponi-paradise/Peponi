namespace Peponi.SourceGenerators.Tests.NotifyInterfaceGenerator;

[TestClass]
public class NotifyInterfaceTest
{
    [TestMethod]
    public void Class()
    {
        Assert.IsTrue(NotifyInterfaceCompare.CompareCode(
@"using Peponi.SourceGenerators;

namespace GeneratorTest;

[NotifyInterface]
public partial class CodeTest
{
}",
@"// Auto generated code by Peponi.SourceGenerators
// Github : https://github.com/peponi-paradise/Peponi
// Blog : https://peponi-paradise.tistory.com

#nullable enable

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GeneratorTest
{
    public partial class CodeTest : INotifyPropertyChanged
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

    [TestMethod]
    public void SealedClass()
    {
        Assert.IsTrue(NotifyInterfaceCompare.CompareCode(
@"using Peponi.SourceGenerators;

namespace GeneratorTest;

[NotifyInterface]
public sealed partial class CodeTest
{
}",
@"// Auto generated code by Peponi.SourceGenerators
// Github : https://github.com/peponi-paradise/Peponi
// Blog : https://peponi-paradise.tistory.com

#nullable enable

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GeneratorTest
{
    public sealed partial class CodeTest : INotifyPropertyChanged
    {
        /// <inheritdoc cref=""INotifyPropertyChanged.PropertyChanged""/>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Raises the <see cref=""PropertyChanged""/> event
        /// </summary>
        /// <param name=""e"">A <see cref=""PropertyChangedEventArgs""/> that contains the name of the changed property.</param>
        private void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref=""PropertyChanged""/> event.
        /// </summary>
        /// <param name=""propertyName"">(optional) The name of the property that changed.</param>
        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
    }
}"));
    }

    [TestMethod]
    public void Record()
    {
        Assert.IsTrue(NotifyInterfaceCompare.CompareCode(
@"using Peponi.SourceGenerators;

namespace GeneratorTest;

[NotifyInterface]
public partial record CodeTest
{
}",
@"// Auto generated code by Peponi.SourceGenerators
// Github : https://github.com/peponi-paradise/Peponi
// Blog : https://peponi-paradise.tistory.com

#nullable enable

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GeneratorTest
{
    public partial record CodeTest : INotifyPropertyChanged
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

    [TestMethod]
    public void Struct()
    {
        Assert.IsTrue(NotifyInterfaceCompare.CompareCode(
@"using Peponi.SourceGenerators;

namespace GeneratorTest;

[NotifyInterface]
public partial struct CodeTest
{
}",
@"// Auto generated code by Peponi.SourceGenerators
// Github : https://github.com/peponi-paradise/Peponi
// Blog : https://peponi-paradise.tistory.com

#nullable enable

using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace GeneratorTest
{
    [StructLayout(LayoutKind.Auto)]
    public partial struct CodeTest : INotifyPropertyChanged
    {
        /// <inheritdoc cref=""INotifyPropertyChanged.PropertyChanged""/>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Raises the <see cref=""PropertyChanged""/> event
        /// </summary>
        /// <param name=""e"">A <see cref=""PropertyChangedEventArgs""/> that contains the name of the changed property.</param>
        private void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref=""PropertyChanged""/> event.
        /// </summary>
        /// <param name=""propertyName"">(optional) The name of the property that changed.</param>
        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
    }
}"));
    }

    [TestMethod]
    public void CustomTypeInherit()
    {
        Assert.IsTrue(NotifyInterfaceCompare.CompareCode(
@"using Peponi.SourceGenerators;

namespace GeneratorTest;

public class BaseClass
{
}

[NotifyInterface]
public partial class CodeTest : BaseClass
{
}",
@"// Auto generated code by Peponi.SourceGenerators
// Github : https://github.com/peponi-paradise/Peponi
// Blog : https://peponi-paradise.tistory.com

#nullable enable

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GeneratorTest
{
    public partial class CodeTest : INotifyPropertyChanged
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