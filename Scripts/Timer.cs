using UnityEngine;
using UnityEngine.Events;

namespace CoreFeatures.Timer
{
    public sealed class Timer : MonoBehaviour
    {
        /// <summary>
        /// Emitted timer type
        /// </summary>
        public enum EmitType
        {
            Periodic,
            OneShot
        }

        /// <summary>
        /// Timeout between emits
        /// </summary>
        public float Timeout { get; private set; }
        /// <summary>
        /// Is timer started
        /// </summary>
        public bool Started { get; private set; }
        /// <summary>
        /// Timer type
        /// </summary>
        public EmitType Type { get; private set; }

        /// <summary>
        /// Emit timer on <see cref="StartTimer"/>
        /// </summary>
        public bool EmitOnStart { get; private set; }

        /// <summary>
        /// The event that must occur when emitting
        /// </summary>
        private UnityEvent _emitEvent = new UnityEvent();

        private float _passedTime = 0;
        //--------------------------------------------------------------------------

        /// <summary>
        /// Add and init (<seealso cref="Init"/>) timer to game object
        /// </summary>
        /// <param name="gameObject">The gameobject to which the timer will be added</param>
        /// <param name="timeout">Timer timeout</param>
        /// <param name="emitOnStart">Emit timer on <see cref="StartTimer"/></param>
        /// <param name="type"></param>
        /// <returns>Timer added on the gameobject</returns>
        public static Timer AddTimer(GameObject gameObject, float timeout, bool emitOnStart = false, EmitType type = EmitType.Periodic)
        {
            Timer timer = gameObject.AddComponent<Timer>();
            timer.Init(timeout, emitOnStart, type);
            return timer;
        }

        /// <summary>
        /// Init timer
        /// </summary>
        /// <param name="timeout">Timer timeout</param>
        /// <param name="emitOnStart">Emit timer on <see cref="StartTimer"/></param>
        /// <param name="type"></param>
        public void Init(float timeout, bool emitOnStart = false, EmitType type = EmitType.Periodic)
        {
            Timeout = timeout;
            Type = type;
            EmitOnStart = emitOnStart;
        }
        //--------------------------------------------------------------------------

        private void Update()
        {
            if (Started)
            {
                _passedTime += Time.deltaTime;

                if (_passedTime >= Timeout)
                {
                    Emit();
                }
            }
        }
        //--------------------------------------------------------------------------

        /// <summary>
        /// Start timer and make first emit if <see cref="EmitOnStart"/>
        /// </summary>
        public void StartTimer()
        {
            _passedTime = 0;
            Started = true;

            if (EmitOnStart)
                Emit();
        }
        //--------------------------------------------------------------------------

        public void StopTimer()
        {
            Started = false;
        }
        //--------------------------------------------------------------------------

        /// <summary>
        /// Add listener on timer emit
        /// </summary>
        /// <param name="callback">Callback on timer emit</param>
        public void AddListener(UnityAction callback)
        {
            _emitEvent.AddListener(callback);
        }
        //--------------------------------------------------------------------------

        private void Emit()
        {
            _passedTime = 0;

            if (Type == EmitType.OneShot)
                StopTimer();

            _emitEvent?.Invoke();
        }
        //--------------------------------------------------------------------------

    }
}