<template>
    <div v-if="show" class="modal-overlay" @click.self="close">
        <div class="modal-wrapper"
             :style="{  maxWidth: width, maxHeight: height }">
            <!-- Header -->
            <div class="modal-header" v-if="title">
                <h2>{{ title }}</h2>
                <button class="close-btn" @click="close">&times;</button>
            </div>

            <!-- Body -->
            <div class="modal-body">
                <slot />
            </div>

            <!-- Footer -->
            <div class="modal-footer" v-if="$slots.footer">
                <slot name="footer" />
            </div>
        </div>
    </div>
</template>

<script setup>import { defineProps, defineEmits } from 'vue';

const props = defineProps({
    show: { type: Boolean, required: true },
    title: { type: String, default: '' },
    width: { type: String, default: '400px'},
    height: { type: String, default: '300px' }
});

const emit = defineEmits(['update:show']);

const close = () => emit('update:show', false);</script>

<style scoped>
    .modal-overlay {
        position: fixed;
        top: 0;
        left: 0;
        width: 100vw;
        height: 100vh;
        background-color: rgba(0, 0, 0, 0.5);
        display: flex;
        align-items: center;
        justify-content: center;
        z-index: 999;
        animation: fadeIn 0.2s ease-in;
        min-width:200px;
        margin:auto;
    }

    .modal-wrapper {
        background-color: #fff;
        border-radius: 12px;
        width: 100%;
        max-height:300px;
        overflow-y: auto;
        padding: 1.5rem;
        box-shadow: 0 10px 25px rgba(0, 0, 0, 0.2);
        display: flex;
        flex-direction: column;
        animation: scaleIn 0.2s ease-in;
    }

    /* Mobile (default) */
    @media (max-width: 767px) {
        .modal-wrapper {
            max-width: 300px;
        }
    }

    /* Desktop */
    @media (min-width: 768px) {
        .modal-wrapper {
            max-width: 500px;
        }
    }

    .modal-wrapper::-webkit-scrollbar-track {
        background: white;
    }

    .modal-header {
        display: flex;
        justify-content: space-between;
        align-items: center;
        margin-bottom: 1rem;
    }

    .modal-header h2 {
        font-size: 1.25rem;
        font-weight: 600;
        margin: 0;
    }

    .close-btn {
        background: none;
        border: none;
        font-size: 1.5rem;
        cursor: pointer;
        line-height: 1;
        transition: transform 0.2s;
        color:black;
    }

    .close-btn:hover {
        transform: rotate(90deg);
        color: #ff4d4f;
    }

    .modal-body {
        flex: 1;
    }

    .modal-footer {
        margin-top: 1rem;
        display: flex;
        justify-content: flex-end;
        gap: 0.5rem;
    }

    /* Animations */
    @keyframes fadeIn {
        from {
            opacity: 0;
        }

        to {
            opacity: 1;
        }
    }

    @keyframes scaleIn {
        from {
            transform: scale(0.95);
            opacity: 0;
        }

        to {
            transform: scale(1);
            opacity: 1;
        }
    }
</style>