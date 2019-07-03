﻿using System;
using Rock.Data;
using Rock.Model;
using Rock.Web.Cache;

namespace Rock.Blocks
{
    public abstract class RockBlockType : IRockBlockType
    {
        #region Properties

        /// <summary>
        /// Gets the block identifier.
        /// </summary>
        /// <value>
        /// The block identifier.
        /// </value>
        public int BlockId => BlockCache.Id;

        /// <summary>
        /// Gets or sets the block cache.
        /// </summary>
        /// <value>
        /// The block cache.
        /// </value>
        public BlockCache BlockCache { get; set ; }

        /// <summary>
        /// Gets or sets the page cache.
        /// </summary>
        /// <value>
        /// The page cache.
        /// </value>
        public PageCache PageCache { get; set; }

        #endregion

        /// <summary>
        /// Gets the attribute value.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public string GetAttributeValue( string key )
        {
            return BlockCache.GetAttributeValue( key );
        }

        /// <summary>
        /// Gets the current person.
        /// </summary>
        /// <returns></returns>
        protected Person GetCurrentPerson()
        {
            var user = UserLoginService.GetCurrentUser( false );

            if ( user == null )
            {
                return null;
            }

            return new PersonService( new RockContext() ).Get( user.PersonId.Value );
        }

        #region Action Response Methods

        /// <summary>
        /// Creates a 200-OK response with no content.
        /// </summary>
        /// <returns>A BlockActionResult instance.</returns>
        protected virtual BlockActionResult ActionOk()
        {
            return new BlockActionResult( System.Net.HttpStatusCode.OK );
        }

        /// <summary>
        /// Create a 200-OK response with the given content value.
        /// </summary>
        /// <typeparam name="T">The type of the content being returned.</typeparam>
        /// <param name="value">The value to be sent to the client.</param>
        /// <returns>A BlockActionResult instance.</returns>
        protected virtual BlockActionResult ActionOk<T>( T value )
        {
            return new BlockActionResult( System.Net.HttpStatusCode.OK, value, typeof( T ) );
        }

        /// <summary>
        /// Create a response with the given status code.
        /// </summary>
        /// <param name="statusCode">The status code.</param>
        /// <returns>A BlockActionResult instance.</returns>
        protected virtual BlockActionResult ActionStatusCode( System.Net.HttpStatusCode statusCode )
        {
            return new BlockActionResult( statusCode );
        }

        /// <summary>
        /// Creates a generic response of the specified status code for the content value.
        /// </summary>
        /// <typeparam name="T">The type of the content being returned.</typeparam>
        /// <param name="statusCode">The status code.</param>
        /// <param name="value">The value to be sent to the client.</param>
        /// <returns>A BlockActionResult instance.</returns>
        protected virtual BlockActionResult ActionContent<T>( System.Net.HttpStatusCode statusCode, T value )
        {
            return new BlockActionResult( statusCode, value, typeof( T ) );
        }

        /// <summary>
        /// Creates a 400-Bad Request response with an optional error message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>A BlockActionResult instance.</returns>
        protected BlockActionResult ActionBadRequest( string message = null )
        {
            if ( message == null )
            {
                return new BlockActionResult( System.Net.HttpStatusCode.BadRequest );
            }
            else
            {
                return new BlockActionResult( System.Net.HttpStatusCode.BadRequest, message );
            }
        }

        /// <summary>
        /// Creates a 404-Not Found response with no content.
        /// </summary>
        /// <returns>A BlockActionResult instance.</returns>
        protected virtual BlockActionResult ActionNotFound()
        {
            return new BlockActionResult( System.Net.HttpStatusCode.NotFound );
        }

        /// <summary>
        /// Creats a 500-Internal Server Error response with an optional error message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>A BlockActionResult instance.</returns>
        protected virtual BlockActionResult ActionInternalServerError( string message = null)
        {
            return new BlockActionResult( System.Net.HttpStatusCode.InternalServerError, message );
        }

        #endregion
    }
}