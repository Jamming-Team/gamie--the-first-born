using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

namespace TheGame
{
    [UxmlElement]
    public partial class ProgressBar : VisualElement
    {
        [SerializeField, DontCreateProperty] private float m_lineWidth = 10f;
        [UxmlAttribute, CreateProperty]
        public float lineWidth
        {
            get => m_lineWidth;
            set
            {
                m_lineWidth = Mathf.Clamp(value, 1f, 100f);
                MarkDirtyRepaint();
            } 
        }
        [SerializeField, DontCreateProperty] private float m_progress = 1f;
        [UxmlAttribute, CreateProperty]
        public float progress
        {
            get => m_progress;
            set
            {
                m_progress = Mathf.Clamp(value, 0f, 1f);
                MarkDirtyRepaint();
            }
        }
        
        [SerializeField, DontCreateProperty] private Color m_color = Color.white;
        [UxmlAttribute, CreateProperty]
        public Color color
        {
            get => m_color;
            set
            {
                m_color = value;
                MarkDirtyRepaint(); 
            }
        }

        public ProgressBar()
        {
            generateVisualContent += GenerateVisualContent;
        }

        private void GenerateVisualContent(MeshGenerationContext context)
        {
            float width = contentRect.width;
            float height = contentRect.height;

            var painter = context.painter2D;

            // Start drawing the line
            painter.BeginPath();
            painter.lineWidth = m_lineWidth;

            // Define the start and end points of the progress bar
            Vector2 startPoint = new Vector2(0f, height * 0.5f);  // Start at the middle-left
            Vector2 endPoint = new Vector2(width * m_progress, height * 0.5f);  // End based on progress

            // Draw the line
            painter.MoveTo(startPoint);
            painter.LineTo(endPoint);

            // Apply styles and render
            painter.strokeColor = m_color;
            // painter.fillColor = m_color;
            // painter.Fill(FillRule.NonZero);
            painter.Stroke();
            // painter.Stro;
        }
    }
}
