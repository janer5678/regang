using GH.Scripts.GameObjects.Contracts;

namespace GH.Scripts.GameObjects
{
    /**
     * Do not call any methods on this object directly.
     * It is to provide a concrete instantiable version of the Character class.
     */
    public class CharacterImpl : Character, IMoveable
    {
        public override void Move()
        {
            throw new System.NotImplementedException();
        }

        public override void Destroy()
        {
            throw new System.NotImplementedException();
        }
    }
}
