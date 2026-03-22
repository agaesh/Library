<!-- ConfirmModal.vue -->
<template>
    <BaseModal :show="modelValue" :title="title" :height="height">

        <div class="confirm-body">
            <p class="message">{{ message }}</p>
        </div>

        <template #footer>
            <button class="btn-secondary custom-rounded"
                    :style="`--custom-radius: 4px`",
                    @click="onCancel">
                {{ cancelText }}
            </button>

            <button :class="[`btn-${variant}`, 'custom-rounded']"
                    :style="`--custom-radius: 4px`"
                    @click="onConfirm">
                {{ confirmText }}
            </button>

        </template>
    </BaseModal>
</template>  

<script setup>
    import BaseModal from './BaseModal.vue'
    import '../../assets/Css/Components/Button.css'

    const props = defineProps({
        modelValue: Boolean,
        title: {
            type: String,
            default: 'Confirm Action'
        },
        message: {
            type: String,
            default: 'Are you sure you want to proceed?'
        },
        confirmText: {
            type: String,
            default: 'Confirm'
        },
        cancelText: {
            type: String,
            default: 'Cancel'
        },
        variant: {
            type: String,
            default: 'primary',
            validator: (value) => ['primary', 'danger', 'success', 'warning'].includes(value)
        }
    })

    const emit = defineEmits(['update:modelValue', 'confirm', 'cancel'])

    const onConfirm = () => {
        emit('confirm')
        emit('update:modelValue', false)
    }

    const onCancel = () => {
        emit('cancel')
        emit('update:modelValue', false)
    }
</script>

<style scoped>

    .message {
        font-size: 14px;
        color: #374151;
    }
</style>
