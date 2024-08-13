using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCrafter.Util.Object.FluentBuilder
{
    /// <summary>
    /// Represents a fluent builder interface for constructing objects of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of object to build.</typeparam>
    public interface IBuilder<T> where T : class
    {
        /// <summary>
        /// Sets properties of the object using the specified action.
        /// </summary>
        /// <param name="action">The action to set properties of the object.</param>
        /// <returns>The current fluent builder instance.</returns>
        protected IBuilder<T> SetProperty(Action<T> action);

        /// <summary>
        /// Sets default values for the object.
        /// </summary>
        /// <returns>The current fluent builder instance.</returns>
        protected IBuilder<T> SetDefaultValues();

        /// <summary>
        /// Clones the fluent builder into an instance of type <typeparamref name="TReturn"/>.
        /// </summary>
        /// <typeparam name="TReturn">The type of fluent builder to clone into.</typeparam>
        /// <returns>A new fluent builder of type <typeparamref name="TReturn"/>.</returns>
        TReturn Clone<TReturn>() where TReturn : IBuilder<T>;

        /// <summary>
        /// Combines the current fluent builder with another builder using the specified combine function.
        /// </summary>
        /// <param name="otherBuilder">The other fluent builder to combine with.</param>
        /// <param name="combineFunc">The function to combine objects of type <typeparamref name="T"/>.</param>
        /// <returns>The current fluent builder instance.</returns>
        IBuilder<T> CombineWith(IBuilder<T> otherBuilder, Func<T, T, T> combineFunc);

        /// <summary>
        /// Builds and returns an instance of type <typeparamref name="T"/>.
        /// </summary>
        /// <returns>An instance of type <typeparamref name="T"/>.</returns>
        T Build();
    }
}