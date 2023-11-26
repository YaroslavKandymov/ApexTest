using System.Collections.Generic;
using UnityEngine;

namespace Entities
{
    [AddComponentMenu("Entities/Entity")]
    public class UnityEntityBase : UnityEntity, ISerializationCallbackReceiver
    {
        [SerializeField]
        private List<MonoBehaviour> elements = new List<MonoBehaviour>();

        private Entity entity;

        public override T Get<T>()
        {
            try
            {
                return entity.Get<T>();
            }
            catch (EntityException exception)
            {
                Debug.LogError(exception.Message, this);
                throw;
            }
        }

        public override T[] GetAll<T>()
        {
            return entity.GetAll<T>();
        }

        public override object[] GetAll()
        {
            return entity.GetAll();
        }

        public override void Add(object element)
        {
            entity.Add(element);
        }

        public override void Remove(object element)
        {
            entity.Remove(element);
        }

        public override bool TryGet<T>(out T element)
        {
            return entity.TryGet(out element);
        }

        public virtual void OnAfterDeserialize()
        {
            entity = new Entity(elements);
        }

        public virtual void OnBeforeSerialize()
        {
        }

#if UNITY_EDITOR
        public void Editor_AddElement(MonoBehaviour elements)
        {
            this.elements.Add(elements);
        }
#endif
    }
}