

namespace AC.Core.Domain.Topics
{
    public partial class Topic : BaseEntity
    {
        public string SystemName { get; set; }

        /// <summary>
        /// Показывает находится ли данный топик в карте сайта
        /// </summary>
        public bool IncludeInSitemap { get; set; }

        /// <summary>
        /// Показывает находится ли данный топик в верхнем меню
        /// </summary>
        public bool IncludeInTopMenu { get; set; }

        /// <summary>
        /// Показывает находится ли данный топик в 1 колонке футера
        /// </summary>
        public bool IncludeInFooterColumn1 { get; set; }

        /// <summary>
        /// Показывает находится ли данный топик в 2 колонке футера
        /// </summary>
        public bool IncludeInFooterColumn2 { get; set; }

        /// <summary>
        /// Показывает находится ли данный топик в 3 колонке футера
        /// </summary>
        public bool IncludeInFooterColumn3 { get; set; }

        /// <summary>
        /// Порядок отображения
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Cодержимое
        /// </summary>
        public string Body { get; set; }

        public bool Published { get; set; }

        public string MetaKeywords { get; set; }

        public string MetaDescription { get; set; }

        public string MetaTitle { get; set; }

    }
}
